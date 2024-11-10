<template>
    <div class="Materias-generales container">
      <div class="lista-materias" v-if="materiasCursandoActualmente.length > 1">
        <div @click="showAlert(materia)" v-for="(materia, index) in materiasCursandoActualmente" :key="index"
             class="materia"
             :style="{ backgroundColor: index % 2 === 0 ? '#fff' : '#9D9D9D' }">
            {{ materia.materia.name }}
        </div>
      </div>
      <div class="wrapper">
        <div class="button-alert" v-if="materiasCursandoActualmente.length > 1">
            <button class="terminar-carga" @click="SetMateriaAsGlobal()" :disabled="!alertVisible">Cambiar a Global</button>
        </div>
        <div :style="{ width: materiasCursandoActualmente.length > 0 ? '100%' : '100%' }" class="wrapper-alertas">
          <div class="alerta" v-if="alertVisible">
            <b-alert show variant="primary">
                <div class="alerta-info">
                    <h5>{{ materiaSelec.name }}</h5>
                    <span>{{ materiaSelec.horarioInicio }} - {{ materiaSelec.horaFinal }}</span><hr>
                    <span>{{ materiaSelec.serie }} </span>
                </div>
            </b-alert>
        </div>
        <div class="alerta" v-if="materiasGlobales.length > 0">
            <h3>Materias globales</h3>
            <b-alert v-for="(materia, index) in materiasGlobales" :key="index" show variant="primary">
                <div class="alerta-info">
                    <h5>{{ materia.materia.name }}</h5>
                    <span>{{ materia.materia.horarioInicio }} - {{ materia.materia.horaFinal }}</span><hr>
                    <span>{{ materia.materia.serie }} </span>
                </div>
            </b-alert>  
        </div>
        </div>
      </div>
    </div>
  </template>
  <script lang="ts">
  import { defineComponent } from "vue";
  import { MateriaVM, MateriasAlumno, Alumno, ResponseType, SemestreVM, MateriasAlumnoVM } from "@/utilities/ViewModels";
  import MateriasService from "@/services/MateriasService";
  
  export default defineComponent({
      props: {
        materiasSemestre: { type: Array }
      },
      data(){
        return{
        materiasCursandoActualmente: [] as MateriasAlumno[],
        materiasGlobales: [] as MateriasAlumno[],
        usuarioLogueado: {} as Alumno,
        alertVisible: false,
        materiaSelec: {} as MateriaVM,
        materiaSelecVM: {} as MateriasAlumnoVM,
        materiaSeleccionadaToSetAsGlobal: {} as MateriasAlumnoVM
        }
      },
      methods: {
        getMateriasCursando() {
          this.usuarioLogueado = JSON.parse(localStorage.loggedUser);
          MateriasService.$GetMateriasCursandoByAlumnoId(this.usuarioLogueado.numeroControl)
          .then((response) => {
            if(response.data.type == ResponseType.Success) {              
              this.materiasCursandoActualmente = response.data.result;
              console.log(this.materiasCursandoActualmente);
              
              this.GetMateriasDisponiblesParaGlobal(this.materiasCursandoActualmente);
              this.$emit("materias-cursando", this.materiasCursandoActualmente);    
              this.$bvToast.toast(response.data.message, {
                  title: `Variante ${'Exitoso' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'success',
                  solid: true,
              });
            }
            else {
              this.$bvToast.toast("response.data.message", {
                  title: `Variante ${'Error' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'danger',
                  solid: true,
              });
            }
          })
          .catch((error) => {
            this.$bvToast.toast(error, {
                  title: `Variante ${'Error' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'danger',
                  solid: true,
              });
          })
        },
        showAlert(materiaSeleccionada: MateriasAlumno) {
          this.materiaSelecVM = {
            materiaId: materiaSeleccionada.materiaId,
            materiaAlumnoid: materiaSeleccionada.materiaAlumnoId,
            maestroId: materiaSeleccionada.maestroId,
            cursada: materiaSeleccionada.cursada,
            numeroControl: materiaSeleccionada.numeroControl
          }
          
            this.alertVisible = true;
            this.materiaSelec = materiaSeleccionada.materia;
            this.materiaSeleccionadaToSetAsGlobal = this.materiaSelecVM; 
            console.log(this.materiaSeleccionadaToSetAsGlobal);
        },
        GetMateriasDisponiblesParaGlobal(materias: MateriasAlumno[]) {   
          console.log(materias);
                
          MateriasService.$GetMateriasDisponiblesParaGlobal(materias)
          .then((response) => {
            this.materiasCursandoActualmente = response.data.result;
            this.GetMateriasGlobales();
          })
        },
        GetMateriasGlobales() {          
          MateriasService.$GetMateriasGlobales(localStorage.userId)
          .then((response) => {
            if(response.data.type == ResponseType.Success) {
              this.materiasGlobales = response.data.result;            
              this.$bvToast.toast(response.data.message, {
                  title: `Variante ${'Exitoso' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'success',
                  solid: true,
              });
            }
            else {
              this.$bvToast.toast(response.data.message, {
                  title: `Variante ${ 'advertencia' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'warning',
                  solid: true,
              });
            }
          })
          .catch(() => {
            this.$bvToast.toast("Ha ocurrido un error al traer las materias globales", {
                  title: `Variante ${ 'advertencia' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'danger',
                  solid: true,
              });
          })
        },
        SetMateriaAsGlobal() {
          MateriasService.$SetMateriaAsGlobal(this.materiaSeleccionadaToSetAsGlobal)
          .then((response) => {
            if(response.data.type == ResponseType.Success) {
              this.$bvToast.toast(response.data.message, {
                  title: `Variante ${'Exitoso' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'success',
                  solid: true,
              });
              this.GetMateriasGlobales();
              window.location.reload(); 
            }
            else {
              this.$bvToast.toast(response.data.message, {
                  title: `Variante ${'Error' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'danger',
                  solid: true,
              });
            }
          });
        }
      },
      mounted() {
        this.getMateriasCursando();
      }
    });
  </script>
  
  <style scoped>
  
  .divisor {
      width: 0.5%;     
      height: 90%;      
      background-color: #9b9b9b; 
      margin-right: 15%;
  }
  
  .lista-materias {
      width: 25%; /* Ajusta al tamaño necesario */ 
      border: 1px solid #000;
  }
  .alerta {
    width: 40%;
    display: flex;
    flex-direction: column;
    align-items: start;
    justify-content: start;
  }

  .alerta-info {
    display: flex;
    flex-direction: column;
    align-items: start;
    text-align: left;
  }

  .wrapper-alertas {
    display: flex;
    gap: 20px;
  }
  
  .materia {
  padding: 10px;
  background-color: #f0f0f0;
  cursor: pointer;
  }

  
  .fondo-blanco {
  background-color: #fff; 
  }
  
  .fondo-gris {
  background-color: #f0f0f0; 
  }
  
  .terminar-carga {
  padding: 10px 20px;
  cursor: pointer;
  border: 1px solid #000;
  background-color: #fff;
  width: 30%;
  }
  
  .info-carga {
      display: flex;
      flex-direction: column;
      align-items: center;
      height: 200px; 
      border: 1px solid #000;
      margin-top: 20px;
      padding: 10px;
  }
  .wrapper {
    display: flex;
    flex-direction: column;
    width: 100%;
    gap: 20px;   
  }
  .Materias-generales {
      display: flex;
      gap: 20px;
  }
  
  .times{
      font-family:'Times New Roman', Times, serif;
  }
  
  .button-alert {
    display: flex;
    flex-direction: column;
    gap: 10%;
  }
  
  </style>