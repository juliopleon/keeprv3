<template>
    <section class="container mt-3">
        <div class="row justify-content-center ">
            <div class="col-md-8 text-center rounded-5 p-5 text-white fs-2 cover d-flex flex-column justify-content-between"
                :style="{ backgroundImage: `url(${vault?.img})` }">
                <h1>{{ vault?.name }}</h1>
                <p>by {{ vault?.creator?.name }}</p>
                <i class="mdi mdi-lock text-secondary fs-2" v-if="vault?.isPrivate"></i>
                <p class="fs-5">{{ vault?.description }}</p>
            </div>
        </div>
        <div class="dropdown mt-5 d-flex" v-if="vault?.creator?.id == account?.id">
            <i class="mdi mdi-dots-horizontal fs-1 justify-content-end" type="button" title="Delete/Edit Vault"
                data-bs-toggle="dropdown" aria-expanded="false"></i>
            <ul class="dropdown-menu ">
                <li data-bs-toggle="modal" data-bs-target="#edit-vault-modal" class="selectable">Edit Vault</li>
                <li @click="removeVault()" class="selectable">Delete Vault</li>

            </ul>
        </div>
        <div class="text-center rounded m-3" v-if="vaultKeeps > 0">

            <p class="fs-1">
                {{ vaultKeeps?.length }} Keeps
            </p>
        </div>
    </section>

    <section class="container">
        <div class="masonry my-5">
            <div v-for="k in vaultKeeps" :key="k.id">
                <KeepCard :keep="k" />
            </div>
        </div>
    </section>
</template>

<!-- Set active vk when i click on a keep only in my vault page -->
<!-- Then bring in to my modal component -->
<!-- Used computed to pass in the right id to the already written vk delete function -->


<script>
import { computed, onMounted } from 'vue';
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import { router } from "../router.js";
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";
import { logger } from '../utils/Logger.js';
import KeepCard from '../components/KeepCard.vue';
export default {
    setup() {
        const route = useRoute();
        async function getKeepsInVault() {
            try {
                await vaultsService.getKeepsInVault(route.params.id);
            }
            catch (error) {
                logger.error(error)
                Pop.error(error)
            }
        }
        async function setVaultActive() {
            try {
                await vaultsService.setVaultActive(route.params.id);
            }
            catch (error) {
                console.error(error);
                Pop.error(error, "Private Vault you do not have access to")
                router.push({ name: "Home" })
            }
        }
        onMounted(() => {
            getKeepsInVault();
            setVaultActive();
        });
        return {
            vault: computed(() => AppState.activeVault),
            vaultKeeps: computed(() => AppState.vaultKeeps),
            user: computed(() => AppState.user),
            account: computed(() => AppState.account),
            activeVaultKeep: computed(() => AppState.activeVaultKeep),
            async removeVault() {
                try {
                    if (await Pop.confirm())
                        await vaultsService.removeVault(route.params.id);
                }
                catch (error) {
                    logger.error(error)
                    Pop.error(error)
                }
            }
        };
    },
    components: { KeepCard }
}
</script>


<style lang="scss" scoped>
.cover {
    background-size: cover;
    background-position: center;
    height: 25rem;
    object-fit: fill;
}

.masonry {
    columns: 4;
}

@media screen AND (max-width: 768px) {
    .masonry {
        columns: 2
    }
}
</style>