<template>
    <div v-if="isVisible" class="modal-overlay">
      <div class="modal-content">
        <p>{{ message }}</p>
        <div class="modal-buttons">
          <button @click="confirm(true)" class="accept-button">Aceptar</button>
          <button @click="confirm(false)" class="cancel-button">Cancelar</button>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      message: {
        type: String,
        required: true
      },
      isVisible: {
        type: Boolean,
        required: true
      }
    },
    methods: {
      confirm(response) {
        this.$emit("confirmationResponse", response); 
      }
    }
  };
  </script>
  
  <style scoped>
  .modal-overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    background-color: rgba(0, 0, 0, 0.5);
    display: flex;
    justify-content: center;
    align-items: center;
    z-index: 1000;
  }
  
  .modal-content {
    background-color: white;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
    text-align: center;
    max-width: 400px;
    width: 100%;
  }
  
  .modal-buttons {
    display: flex;
    justify-content: space-around;
    margin-top: 20px;
  }
  
  .accept-button {
    background-color: green;
    color: white;
    padding: 10px 20px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }
  
  .cancel-button {
    background-color: red;
    color: white;
    padding: 10px 20px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }
  
  .accept-button:hover,
  .cancel-button:hover {
    opacity: 0.8;
  }
  </style>
  