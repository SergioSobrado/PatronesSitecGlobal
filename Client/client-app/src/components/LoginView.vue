<template>
    <div class="vista">
        <div class="fondo container">
            <div class="formulario">
                <h1 class="times">Sistema Gestor de Materias</h1>
                <b-form-input id="type-password" type="text" v-model="numeroControl" placeholder="Número de control"
                    class="times"></b-form-input>
                <b-form-input id="input-default" placeholder="Clave" class="times" v-model="password"></b-form-input>
                <div class="boton">
                    <b-button variant="light" class="times" @click="Login">Entrar</b-button>
                </div>
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import AlumnoService from "@/services/AlumnoService"
import { ResponseType } from '@/utilities/ViewModels'
import { defineComponent } from "vue"

export default defineComponent({
    data() {
        return {
            password: "",
            numeroControl: 0
        }
    },
    methods: {
        Login() {
            if (this.password != "" && this.numeroControl > 0) {
                AlumnoService.$LoggedUser(this.numeroControl, this.password)
                    .then((response) => {
                        if (response.data.type == ResponseType.Success) {
                            localStorage.loggedUser = JSON.stringify(response.data.result);
                            localStorage.userId = response.data.result.numeroControl;
                            this.$emit("get-user-id", localStorage.userId);
                            this.$bvToast.toast(response.data.message, {
                                title: `Variante ${'Exitoso' || 'default'}`,
                                toaster: 'b-toaster-bottom-right',
                                variant: 'success',
                                solid: true,
                            });
                        }
                        else{
                            this.$bvToast.toast(response.data.message, {
                                title: `Variante default`,
                                toaster: 'b-toaster-bottom-right',
                                variant: 'warning',
                                solid: true,
                            });
                        }
                    })
            }
            else {
                this.$bvToast.toast("Rellena todos los campos", {
                    title: `Variante ${'Aviso' || 'default'}`,
                    toaster: 'b-toaster-bottom-right',
                    variant: 'warning',
                    solid: true,
                });
            }

        },
    }
});
</script>
<style scoped>
.vista {
    width: 100%;
    height: 100%;
}

.formulario {
    width: 40%;
    height: 40%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;

}

.fondo {
    background-color: #c5c5c5;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.boton {
    display: flex;
    flex-direction: column;
    align-self: flex-end;
}

.times {
    font-family: 'Times New Roman', Times, serif;
}
</style>