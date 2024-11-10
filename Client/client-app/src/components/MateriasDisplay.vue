<template>
  <div class="Materias-generales container">
    <div class="lista-materias">
      <div v-for="(materia, index) in materiasSemestre" :key="index"
           class="materia"
           :style="{ backgroundColor: index % 2 === 0 ? '#fff' : '#9D9D9D' }"
           @click="selectMateria(materia)">
          {{ materia.materia.name}}<br />
          {{ materia.materia.horarioInicio }} - {{ materia.materia.horaFinal }}
      </div>
    </div>
    <div class="lista-materias">
      <div v-for="(materia, index) in materiasSeleccionada" :key="index"
           class="materia"
           :style="{ backgroundColor: index % 2 === 0 ? '#fff' : '#9D9D9D' }">
          {{ materia.name }} <br />
          {{ materia.horarioInicio }} - {{ materia.horaFinal }}


      </div>
    </div>
      <div class="panel-carga">
        <button class="terminar-carga" @click="finishCarga" :disabled="oldMateria.length <= 0">Terminar Carga</button>
        <div class="info-carga">
          Créditos: <br>
          Min: {{ creditosMin }} <br>
          Usados: {{ creditosActuales }} <br>
          Max: {{ creditosMax }}
        </div>
    </div>
  </div>
</template>
<script lang="ts">
import { defineComponent } from "vue";
import { MateriaVM, MateriasAlumno, Alumno, ResponseType, MateriasAlumnoVM } from "@/utilities/ViewModels";
import MateriasService from "@/services/MateriasService";

export default defineComponent({
    props: {
      materiasSemestre: { type: Array }
    },
    data(){
      return{
      materiasSeleccionada: [] as MateriaVM[],
      listOfMaterias: [] as MateriaVM[],
      oldMateria: [] as MateriasAlumnoVM[],
      materiasCursandoActualmente: [] as MateriasAlumno[],
      creditosActuales: 0,
      creditosMin: 15,
      creditosMax: 36,
      usuarioLogueado: {} as Alumno,
      materiasVM: {} as MateriasAlumnoVM
      }
    },
    methods: {
      selectMateria(materia: MateriasAlumno) {
        this.materiasVM = {
          materiaId: materia.materiaId,
          materiaAlumnoid: materia.materiaAlumnoId,
          maestroId: materia.maestroId,
          cursada: materia.cursada,
          numeroControl: materia.numeroControl
        }
        if(materia.materia!.isSelected) {
          materia.materia!.isSelected = false;
          let indice = this.materiasSeleccionada?.indexOf(materia.materia!);
          this.materiasSeleccionada.splice(indice as number, 1);
          this.creditosActuales -= materia.materia.creditos;
          let indice2 = this.oldMateria?.indexOf(this.materiasVM);
          this.oldMateria.splice(indice2 as number, 1);
        }
        else {
          this.materiasSeleccionada.push(materia.materia!);
          this.oldMateria.push(this.materiasVM);
          this.creditosActuales += materia.materia.creditos;
          materia.materia!.isSelected = true;
          this.materiasSeleccionada = this.materiasSeleccionada.filter((item, index) => {
            return this.materiasSeleccionada.indexOf(item) === index
          });
        }
      },
      finishCarga() {
        if(this.creditosActuales < this.creditosMin) {
          this.$bvToast.toast("Debes alcanzar el minimo de creditos para cargar tus materias", {
                title: `Variante ${'advertencia' || 'default'}`,
                toaster: 'b-toaster-bottom-right',
                variant: 'warning',
                solid: true,
          });
        }
        if(this.creditosActuales > this.creditosMax) {
          this.$bvToast.toast("No puedes cargar mas creditos que los creditos maximos especificados", {
                title: `Variante ${'advertencia' || 'default'}`,
                toaster: 'b-toaster-bottom-right',
                variant: 'warning',
                solid: true,
          });
        }
        if(this.creditosActuales < this.creditosMax && this.creditosActuales >= this.creditosMin) {
          MateriasService.$finishCarga(this.oldMateria)
          .then((response) => {
          if(response.data.type == ResponseType.Success) {
            this.$bvToast.toast(response.data.message, {
                title: `Variante ${'Exitoso' || 'default'}`,
                toaster: 'b-toaster-bottom-right',
                variant: 'success',
                solid: true,
            });
            this.getMateriasCursando();
          }
          else {
            this.$bvToast.toast(response.data.message, {
                title: `Variante ${'Error' || 'default'}`,
                toaster: 'b-toaster-bottom-right',
                variant: 'danger',
                solid: true,
            });
          }
        })
        }
      },
      getMateriasCursando() {
        this.usuarioLogueado = JSON.parse(localStorage.loggedUser);
        MateriasService.$GetMateriasCursandoByAlumnoId(this.usuarioLogueado.numeroControl)
        .then((response) => {
          if(response.data.type == ResponseType.Success) {
            this.materiasCursandoActualmente = response.data.result;
            this.materiasCursandoActualmente.forEach((m) => {
              m.alumno = JSON.parse(localStorage.loggedUser);
            });
            this.materiasCursandoActualmente.forEach((materia) => {
            this.creditosActuales += materia.materia.creditos;
          })          
          if(this.materiasCursandoActualmente.length > 0) {
            this.materiasSeleccionada = [];
            this.materiasCursandoActualmente.forEach((materia) => {
              this.materiasSeleccionada.push(materia.materia);
            });
            this.$emit("materias-cursando", this.materiasCursandoActualmente);
          }
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

.panel-carga {
  width: 10%; 
  display: flex;
  flex-direction: column;
  align-items: center;
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
}

.info-carga {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-around;
    height: 200px; 
    border: 1px solid #000;
    margin-top: 20px;
    padding: 10px;
}

.Materias-generales {
    display: flex;
    justify-content: space-between;
}

.times{
    font-family:'Times New Roman', Times, serif;
}


</style>