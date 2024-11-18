<template>
  <div id="app">
    <nav>
      <div class="imagenes">
        <img src="@/assets/TECNM.png" width="200"  alt="tecnologico de mexico">
        <img src="@/assets/itt.png" width="80" alt="tec">
      </div>
      <div class="nav-user times" v-if="userId > 0 && !isAdmin">
        <a @click="goTo('/')">Perfil</a>
        <a @click="goTo('/materias')">Carga de Materia</a>
        <a @click="goTo('/global')">Carga de Materia Global</a>
      </div>
      <div class="nav-user times" v-if="userId > 0 && isAdmin">
        <a @click="goTo('/admin')">Solicitudes</a>
      </div>
    </nav>
    <router-view style="height: 100%;" v-if="userId > 0"/>
    <div v-else class="body">
      <LoginView @get-user-id="getLoggedUser"/>
    </div>
  </div>
</template>
<script lang="ts">
import { defineComponent } from "vue"
import LoginView from '@/components/LoginView.vue'
import { Alumno } from "./utilities/ViewModels";

export default defineComponent({
  components:{
    LoginView,
  },
  data() {
    return {
      usuarioLogueado: false,
      loggedUser: {} as Alumno,
      userId: 0,
      isAdmin: false,
    }
  },
  methods: {
    goTo(ruta: string) {
      this.$router.push(ruta).catch(err => {
    // Ignore the vuex err regarding  navigating to the page they are already on.
    if (
      err.name !== 'NavigationDuplicated' &&
      !err.message.includes('Avoided redundant navigation to current location')
    ) {
      // But print any other errors to the console
      console.log(err);
    }
  });
    },
    getLoggedUser() {      
      if(localStorage.loggedUser != undefined || localStorage.loggedUser != null) {
        this.loggedUser = JSON.parse(localStorage.loggedUser);
      }
      else {
        this.loggedUser = {} as Alumno;
      }      
      this.userId = localStorage.userId;
      this.isAdmin = this.loggedUser.isAdmin;
      console.log(this.isAdmin);
      
    },
  },
  mounted() {
    this.getLoggedUser();
  }
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

.body{
  width: 100%;
  height: calc(100vh - 83px);
}

.imagenes{
  display: flex;
  align-content: center;
  gap: 40%;
  justify-content: space-around;
  background-color: rgb(221, 221, 221);
}
.nav-user{
  display: flex;
  justify-content: space-evenly;
  background-color: rgb(193, 193, 193);
}
nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}

.times{
    font-family:'Times New Roman', Times, serif;
}
</style>
