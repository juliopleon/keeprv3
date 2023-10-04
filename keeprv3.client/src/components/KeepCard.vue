<template>
    <div class="card text-bg-warning border-0 my-3 elevation-5 selectable hover " :title="keep?.name" data-bs-toggle="modal"
        data-bs-target="#keep-modal" @click="getActiveKeep(keep?.id)">
        <i class="mdi mdi-delete text-white bg-danger rounded-circle selectable on-hover text-center"
            v-if="keep?.creator?.id == account?.id" title="Remove Keep" @click="deleteKeep()"></i>
        <img :src="keep?.img" class="card-img  rounded-4" alt="...">
        <div class="card-img-overlay align-items-end d-flex justify-content-between">
            <h5 class="card-title text-white">{{
                keep?.name
            }}</h5>
            <img :src="keep.creator?.picture" class="person rounded-circle border border-white border-1" alt="" height="40"
                width="40" :title="keep?.creator?.name" v-if="home">
        </div>
    </div>
    <Modal id="keep-modal">
        <KeepModel />
    </Modal>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted, watchEffect } from 'vue';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';
import { useRoute } from "vue-router";
import { Modal } from "bootstrap";
export default {
    props: {
        keep: {
            type: Object,
            required: true
        }
    },
    setup(props) {

        const editable = ref({})
        const route = useRoute()
        onMounted(() => {

        });
        watchEffect(() => { });



        return {
            editable,
            account: computed(() => AppState.account),
            home: computed(() => route.name == 'Home'),



            async getActiveKeep(keepId) {
                try {
                    await keepsService.getActiveKeep(keepId);
                } catch (error) {
                    logger.log(error)
                    Pop.error(error)
                }
            },

            async deleteVaultKeep() {
                try {
                    debugger
                    if (await Pop.confirm()) {
                        await keepsService.deleteVaultKeep(props.keep.id)
                        Modal.getOrCreateInstance('#keep-modal').hide()
                    }
                } catch (error) {
                    logger.log(error)
                    Pop.error(error)
                }
            },

            // async getKeptDetails() {
            //     try {
            //         await vaultsService.getKeptDetails()
            //     } catch (error) {
            //         logger.log(error)
            //         Pop.error(error)
            //     }
            // },
        }
    }
};
</script>


<style lang="scss" scoped>
i {
    position: absolute;
    right: 0;
    height: 20px;
    width: 20px;
    z-index: 9999;
}

.card-title {
    font-family: 'Marko One';
    font-style: normal;
    font-weight: 600;
    font-size: 22px;
    line-height: 29px;
}
</style>