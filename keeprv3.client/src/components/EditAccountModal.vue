<template>
    <div class="row">

        <div class="col-md-6 p-4 text-black modal-body">
            <form class=" account-form acc-bio p-3 rounded" @submit.prevent="handleSubmit()">
                <div class="acc-pic text-start">
                    <div>
                        <label for="name">Name:</label>
                        <input type="text" class="form-control" v-model="editable.name">
                    </div>
                    <div>
                        <label for="picture">Picture:</label>
                        <input type="url" class="form-control" v-model="editable.picture" name="picture"
                            placeholder="picture">
                    </div>
                    <div>
                        <label for="coverImg">Cover Image:</label>
                        <input type="url" class="form-control" v-model="editable.coverImg" name="coverImg">
                    </div>
                    <div class="col-md-2">
                        <button type="submit" class="btn btn-dark w-100 mt-2 ">Save</button>
                    </div>
                </div>
            </form>
        </div>


        <div class="col-md-6 elevation-5  d-flex justify-content-center align-items-center text-shadow rounded-end"
            :style="{ backgroundImage: `url(${editable.coverImg})` }">

            <div>
                <img :src="editable.picture" alt="" class="rounded-circle border border-white border-4" height="150"
                    width="150">
                <h4 class="text-center my-3">{{ editable.name }}</h4>
            </div>


        </div>

    </div>
</template>


<script>
import { Modal } from "bootstrap";
import { ref, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { accountService } from "../services/AccountService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
export default {
    setup() {
        const editable = ref({})
        watchEffect(() => {
            editable.value = { ...AppState.account }
        })
        return {
            editable,

            async handleSubmit() {
                try {
                    await accountService.editAccount(editable.value)
                    Modal.getOrCreateInstance('#edit-account-modal').hide()
                } catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>