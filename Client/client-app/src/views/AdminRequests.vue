<template>
  <div class="home container">
    <div class="info container">
      <div style="display: flex; justify-content: space-between; width: 85%;">
        <h1>{{ loggedUser.name }}</h1>
        <button @click="singOut" class="log-out">Cerrar sesion</button>
      </div>
      

      <div class="petitions-container">
        
        
          <div class="petition-card" @click="goTo('/sobrecargas')">
            <div>
              <h3>Peticiones de Sobrecargas</h3>
            <hr class="divider" />
            <p class="times">Peticiones pendientes: 23123</p>
          </div>
        </div>      
        <div class="petition-card" @click="goTo('/globales')">
            <div>
              <h3>Peticiones de Globales</h3>
            <hr class="divider" />
            <p class="times">Peticiones pendientes: 23123</p>
          </div>
        
        </div>
        
        <div class="petition-card" @click="goTo('/ajustes')">
            <div>
              <h3>Peticiones de Ajustes</h3>
          
            <hr class="divider" />
            <p class="times">Peticiones pendientes: 23123</p>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Alumno } from "@/utilities/ViewModels";
import { defineComponent } from "vue";


export default defineComponent({
  data(){
    return{
      loggedUser: {} as Alumno
    };
  },
  methods:{
    goTo(path:string){
      this.$router.push({path:path});
    },
    singOut() {
      localStorage.clear();
      this.$router.push('/');
      window.location.reload();
    },
    getLoggedUser() {
      this.loggedUser = JSON.parse(localStorage.loggedUser);
    }
  },
  mounted() {
    this.getLoggedUser();
  }
});
</script>

<style scoped>
.info {
  display: flex;
  gap: 5%;
  padding-top: 5%;
  flex-direction: column;
  align-items: center;
  height: 100dvh;
  background-color: rgb(210, 209, 209);
}

.home {
  height: 100%;
}
.log-out{
  background: #ffffff;
  display: flex;
  align-items: end;
  border-radius: 8px;
  border: 2px solid rgb(172, 171, 171);
  text-align: center;
  align-items: center; 
  justify-content: center;
}

.petitions-container {
  display: flex;
  gap: 10px;
  justify-content: center;
  width: 100%;
}

.petition-card {
  background-color: #ffffff;
  padding: 20px;
  width: 250px;
  height: 225px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  border-radius: 8px;
  border: 2px solid rgb(172, 171, 171);
  text-align: center;
  align-content: center;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.petition-card:hover {
  transform: scale(1.05); 
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2); 
}

.petition-title {
  min-height: 120px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.divider {
  height: 2px;
  margin: 10px auto;
  background-color: rgb(172, 171, 171);
  border: none;
}

.times {
  font-family: "Times New Roman", Times, serif;
}

.petition-link {
  text-decoration: none;
  color: #2c3e50;
  font-weight: bold;
}

.petition-link:hover {
  color: #090b8a;
}
</style>