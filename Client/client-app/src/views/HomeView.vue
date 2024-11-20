<template>
  <div class="home container">
    <div class="info container ">
      <h1>Informacion del estudiante</h1>
      <div class="datos">
        <img class="imagen" src="@/assets/avatar.jpg" alt="imgan-placeholder">
        <div class="info-user times">
          <h3>{{ alumnoVM.name }}</h3>
          <h3>{{ alumnoVM.carrera }}</h3>
          <h3>{{ alumnoVM.semestre.name }}</h3>
        </div>
      </div>
      <hr>
      <div class="container materias">
        <h2>Horario</h2>
        <div v-if="materiasActuales.length > 0">
          <b-alert v-for="(materiaSelec, index) in materiasActuales" :key="index" show :variant="variants[index]">
            <div class="alerta-info">
                <h5>{{ materiaSelec.materia.name }}</h5>
                <span>{{ materiaSelec.materia.horarioInicio }} - {{ materiaSelec.materia.horaFinal }}</span><hr>
                <span>{{ materiaSelec.maestro?.name }} </span>
            </div>
          </b-alert>  
        </div>
        <div class="alerta" v-if="materiasGlobales.length > 0">
            <h3>Materias globales</h3>
            <b-alert v-for="(materia, index) in materiasGlobales" :key="index" show variant="primary">
                <div class="alerta-info">
                    <h5>{{ materia.materia.name }}</h5>
                    <span>{{ materia.materia.horarioInicio }} - {{ materia.materia.horaFinal }}</span><hr>
                    <span>{{ materia.maestro?.name }} </span>
                </div>
            </b-alert>  
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import AlumnoService from "@/services/AlumnoService";
import MateriasService from "@/services/MateriasService";
import { Alumno, AlumnoVM, MateriasAlumno, ResponseType } from "@/utilities/ViewModels"
import { defineComponent } from "vue";
export default defineComponent({
  data() {
    return {
      loggedUser: {} as Alumno,
      alumnoVM: {} as AlumnoVM,
      materiasSemestre: [] as MateriasAlumno[],
      newMaterias: [] as MateriasAlumno[],
      materiasActuales: [] as MateriasAlumno[],
      variants: ['primary', 'warning', 'danger', 'primary', 'info','primary', 'warning', 'danger','primary', 'warning', 'danger'],
      materiasGlobales: [] as MateriasAlumno[]
    };
  },
  methods: {
    getLoggedUser() {
      this.loggedUser = JSON.parse(localStorage.loggedUser);

      this.getMateriasCursando();

      AlumnoService.$GetAlumnoByAlumnoId(this.loggedUser.numeroControl)
      .then((response) => {
        this.alumnoVM = response.data.result;
      })
      .catch((error) => {
        console.log(error);
      })
    },
    getMateriasCursando() {
      MateriasService.$GetMateriasCursandoByAlumnoId(this.loggedUser.numeroControl)
          .then((response) => {
            if(response.data.type == ResponseType.Success) {
              this.materiasActuales = response.data.result;
              this.$bvToast.toast(response.data.message, {
                  title: `Variante ${'Exitoso' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'success',
                  solid: true,
              });
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
          .catch((error) => {
            this.$bvToast.toast(error, {
                  title: `Variante ${'Error' || 'default'}`,
                  toaster: 'b-toaster-bottom-right',
                  variant: 'danger',
                  solid: true,
              });
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
              if(this.materiasGlobales.length > 0) {
                this.$emit("send-globales", this.materiasGlobales);
              }
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
  },
  mounted() {
    this.getLoggedUser();
    this.GetMateriasGlobales();
  }
});
</script>


<style scoped>
.imagen{
  border-radius: 5%;
  width: 500px;
}

.materias {
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center
}

.info{
  display: flex;
  flex-direction: column;
  align-items: start;
  height: 100%;
  background-color: rgb(210, 209, 209);
}

.home {
  height: 100%;
}
.datos{
  display: flex;
  gap: 3%;
  padding: 2%;
  width: 100%;
}

.alerta-info {
  display: flex;
  gap: 10px;
}

.info-user{
  display: flex;
  flex-direction: column;
  align-items: start;
  justify-content: center;
  gap: 3%;
  width: 100%;
}

.times{
    font-family:'Times New Roman', Times, serif;
    font-size: large;
}

.timesxlarge{
    font-family:'Times New Roman', Times, serif;
    font-size:xx-large;
}
</style>