<template>
    <div class="modal-body">
        <div class="row">
            <div class="col-md-6">
                <div class="d-flex justify-content-between">
                    <h2 class="mb-5 ms-3">Create Your Vault</h2>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <form @submit.prevent="createVault()">
                    <div class="form mb-3">
                        <input v-model="editable.name" required type="text" class="form-control" id="VaultName"
                            placeholder="Title...">

                    </div>
                    <div class="form mb-3">
                        <textarea v-model="editable.description" required type="text" class="form-control"
                            id="vaultDescription" placeholder="Description...">
          </textarea>
                    </div>

                    <div>
                        <p class="private p-0">Private Vaults can only be seen by you</p>
                        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault"
                            v-model="editable.isPrivate">
                        <label class="form-check-label" for="flexCheckDefault">
                            <p class="ms-2"> Make Vault Private? </p>
                        </label>
                    </div>


                    <input v-model="editable.img" type="url" class="form-control" id="reportRating">
                    <button type="submit" class="btn btn-dark">Create Vault</button>
                </form>

            </div>



            <div class="col-md-6  rounded-3 text-shadow elevation-5" :style="{ backgroundImage: `url(${editable.img})` }">
                <p class="text-shadow fs-3 d-flex  justify-content-center">{{ editable.name }}</p>
                <i class="mdi mdi-lock fs-4 d-flex  justify-content-end" v-if="editable.isPrivate == true"></i>
                <p>{{ editable.description }}</p>
            </div>


        </div>


    </div>
</template>


<script>
import { Modal } from "bootstrap";
import { ref } from 'vue';
import { vaultsService } from "../services/VaultsService.js";
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            async createVault() {
                try {
                    debugger
                    await vaultsService.createVault(editable.value)
                    Modal.getOrCreateInstance('#create-vault-modal').hide()
                } catch (error) {
                    logger.error(error)
                    Pop.error(error.message)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.private {
    font-size: 8pt;
}
</style>