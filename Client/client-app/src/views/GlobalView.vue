<template>
  <div class="global container">
      <h1>Carga de materias</h1>
      <div class="Materias-general">
        <div class="info">
          <h4>Mis Materias</h4>
          <span>Aqui puedes ver tus clases normales y clases que puedes convertir en global si tienes horario chocando</span>
        </div>
      </div>
      <MateriasGlobal :materiasSemestre="materiasSemestre" @materias-cursando="getMateriasCursando"/>
      <h2 class="subtitulo times ">Tu horario</h2>
      <div class="lista-materias">
        <div style="text-align: left;" v-for="(materias, index) in materiasActuales" :key="index">
          <b-alert show :variant="variants[index]">
            <h5>{{ materias.materia.name }}</h5>
            <span>{{ materias.materia.horarioInicio }} - {{ materias.materia.horaFinal }} - {{ index % 2 === 0 ? "L - V": "L - J" }}</span> <br>
            <span>{{ materias.materia.serie }}</span><br>
            <span>{{ materias.maestro?.name }}</span>
          </b-alert>
        </div>
      </div>
  </div>
</template>
<script lang="ts">
import { defineComponent } from "vue";
import { Alumno, MateriasAlumno } from "@/utilities/ViewModels";
import MateriasGlobal from '@/components/MateriasGlobal.vue'
import MateriasService from '@/services/MateriasService'

export default defineComponent({
components:{
    MateriasGlobal
  },
  data(){
    return{
    usuarioLogueado: {} as Alumno,
    materiasSemestre: [] as MateriasAlumno[],
    newMaterias: [] as MateriasAlumno[],
    materiasActuales: [] as MateriasAlumno[],
    variants: ['primary', 'warning', 'danger', 'primary', 'info','primary', 'warning', 'danger','primary', 'warning', 'danger']
    }
  },
  methods: {
    getLoggedUser() {
      this.usuarioLogueado = JSON.parse(localStorage.loggedUser);
      this.getMateriasBySemestreId(this.usuarioLogueado.numeroControl);
    },
    getMateriasBySemestreId(numeroControl: number) {
      MateriasService.$GetMateriasBySemestreId(numeroControl)
      .then((response) => {
        this.materiasSemestre = response.data.result;
        this.materiasSemestre.forEach((materias) => {
          materias.materia!.isSelected = false;
        })
        this.newMaterias = this.materiasSemestre;
      })
    },
    getMateriasCursando(materias: MateriasAlumno[]) {
      this.materiasActuales = materias;
    },
  },
  mounted() {
    this.getLoggedUser();
  }
});
</script>
<style scoped>
.global{
  display: flex;
  flex-direction: column;
  align-items : start;
  background-color: rgb(213, 213, 213);
  height: 100%;
  width: 100%;
  padding: 2%;
}

.subtitulo{
display: flex;
margin-top: 3%;
margin-left: 3%;
}

.Materias-general{
  display: flex;
  gap: 20%;
  padding: 2%;
  align-content: space-between;
  width: 90%;
}

.info{
  display: flex;
  flex-direction: column;
  text-align: start;
}

.carga{
border: red solid;
width: 300px; /* Tamaño fijo del contenedor */
height: 200px; /* Tamaño fijo del contenedor */
overflow: auto;
}

.materia {
/* Estilos de las materias */
padding: 2%;
margin-bottom: 5px;
background-color: #f0f0f0;
}

.table-container {
overflow-x: auto; /* Agrega una barra de desplazamiento horizontal si el contenido es demasiado ancho */
}

.horario-table {
width: 100%; /* La tabla abarca todo el ancho del contenedor */
border-collapse: collapse;
}

.horario-table th, .horario-table td {
border: 1px solid #ddd;
padding: 8px;
}

.horario-table th.day-cell {
background-color: rgb(210, 209, 209); /* Color de fondo para las celdas de los días de la semana */
}

.horario-table td.white-cell {
background-color: #fff; /* Color de fondo blanco para las celdas de datos */
}

.horario-table td {
text-align: center;
}

.lista-materias {
  width: 80%;
  height: fit-content;
}
</style>