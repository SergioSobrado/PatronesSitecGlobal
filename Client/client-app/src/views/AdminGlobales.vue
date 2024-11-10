<template>
  <div class="info container">
    <div class="header">
      <button class="back-button" @click="goTo('/admin')">⬅</button>
      <div class="title-bar">
        <h1>Peticiones de Globales</h1>
        <div class="search-bar">
          <input type="text" placeholder="Buscar..." />
          <button class="search-icon">🔍</button>
        </div>
      </div>
    </div>
    <table style="background-color: white;" class="table">
      <thead>
        <tr>
          <th>Fecha</th>
          <th>Nombre del alumno</th>
          <th>Número de control</th>
          <th>Semestre</th>
          <th>Promedio</th>
          <th>Materias reprobadas</th>
          <th>Acción</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(row, index) in rows" :key="index">
          <td>{{ row.createdOn }}</td>
          <td>{{ row.name }}</td>
          <td>{{ row.numeroControl }}</td>
          <td>{{ row.semestre }}</td>
          <td>{{ row.promedio }}</td>
          <td>{{ row.reprobadas }}</td>
          <td>
            <button @click="openModal('¿Aceptar esta petición?', row.id)" class="confirm-action">✔️</button>
            <button @click="openModal('¿Rechazar esta petición?', row.id, false)" class="reject-action">❌</button>
          </td>
        </tr>
      </tbody>
    </table>

    <ConfirmationModal 
      v-if="isModalVisible" 
      :message="modalMessage" 
      :isVisible="isModalVisible" 
      @confirmationResponse="handleConfirmation"
    />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import ConfirmationModal from '@/components/ConfirmationModal.vue';
import { RequestVM } from '@/utilities/ViewModels';

export default defineComponent({
  components: {
    ConfirmationModal
  },
  data() {
    return {
      rows: [
        { id: 1, createdOn: '##/##/####', name: 'Gonzalez Dominguez Yahir Emiliano', numeroControl: 20211783, semestre: 9, promedio: 94, reprobadas: 0 },
        { id: 2, createdOn: '##/##/####', name: 'Gonzalez Dominguez Yahir Emiliano', numeroControl: 20211783, semestre: 9, promedio: 94, reprobadas: 0 },
        { id: 3, createdOn: '##/##/####', name: 'Gonzalez Dominguez Yahir Emiliano', numeroControl: 20211783, semestre: 9, promedio: 94, reprobadas: 0 },
        { id: 4, createdOn: '##/##/####', name: 'Gonzalez Dominguez Yahir Emiliano', numeroControl: 20211783, semestre: 9, promedio: 94, reprobadas: 0 },
        { id: 5, createdOn: '##/##/####', name: 'Gonzalez Dominguez Yahir Emiliano', numeroControl: 20211783, semestre: 9, promedio: 94, reprobadas: 0 }
      ] as RequestVM[],
      isModalVisible: false,
      modalMessage: '',
      selectedRequestId: 0 as number | null,
      isAcceptAction: true,
      selectedRequest: {} as RequestVM,
    };
  },
  methods: {
    goTo(path:string) {
      this.$router.push({ path: path });
    },
    openModal(message:string, rowId:number, isAccept = true) {
      this.modalMessage = message;
      this.isModalVisible = true;
      this.selectedRequestId = rowId;
      this.isAcceptAction = isAccept;
      
    },
    handleConfirmation(response: boolean) {
      this.isModalVisible = false;
      this.selectedRequest = this.rows.find((x)=> x.id == this.selectedRequestId) ?? {} as RequestVM;
      if (response && Object.keys(this.selectedRequest).length != 0) {
        if (this.isAcceptAction) {
          console.log(`Petición aceptada para el alumno: ${this.selectedRequest.name}`);
        } else {
          console.log(`Petición rechazada para el alumno: ${this.selectedRequest.name}`);
        }
      } else {
        console.log("Acción cancelada");
      }
    }
  }
});
</script>

<style scoped>
.info {
  gap: 5%;
  padding-top: 3%;
  align-items: center;
  height: 100%;
  background-color: rgb(210, 209, 209);
}

.header {
  display: flex;
  flex-direction: column;
  align-items: start;
  row-gap: 10px;
  margin-bottom: 20px;
}

.back-button {
  font-size: 24px;
  background: #ffffff;
  border: 2px solid rgb(172, 171, 171);
  cursor: pointer;
  color: #333;
}

.title-bar {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
}

.search-bar {
  display: flex;
  align-items: center;
  gap: 2px;
}

.search-bar input {
  padding: 8px;
  font-size: 14px;
  border: 2px solid rgb(172, 171, 171);
  border-radius: 4px;
}

.search-icon {
  background-color: #ffffff;
  border: 2px solid rgb(172, 171, 171);
  padding: 8px;
  cursor: pointer;
  border-radius: 4px;
}

.table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

th, td {
  padding: 12px;
  border: 1px solid #ddd;
  text-align: left;
}

th {
  background-color: #f2f2f2;
}

.confirm-action, .reject-action {
  padding: 8px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  color: white;
  font-size: 16px;
}

.back-button:hover, .search-bar input:hover, .search-icon:hover, .confirm-action:hover, .reject-action:hover {
  transform: scale(1.05);
  box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
}

.confirm-action {
  background-color: green;
}

.reject-action {
  background-color: red;
}
</style>