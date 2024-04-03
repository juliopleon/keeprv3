<template>
    <div class="container pt-4">
        <div class="col-8 about text-center cover container rounded-5 "
            :style="{ backgroundImage: `url(${profile?.coverImg})` }">
            <div class=" info mb-5">
                <img class="rounded-circle border border-white border-3" height="100" width="100" :src="profile?.picture"
                    alt="" />
                <h1>{{ profile?.name }}</h1>
                <p class="fs-1">
                    {{ vaults.length }} Vaults | {{ keeps.length }} Keeps
                </p>
            </div>
        </div>
        <div class="stuff">
            <div class="container-fluid">
                <h3 class="text-center">Vaults</h3>
                <section class="container vaults mt-5">
                    <div class="d-flex">
                        <div v-for="v in vaults" :key="v.id">
                            <VaultCard :vault="v" />
                        </div>
                    </div>
                </section>
            </div>
            <h3 class="mt-5 text-center mb-5">Keeps</h3>
            <section class="container">
                <div class="masonry my-3">
                    <div v-for="k in keeps" :key="k.id">
                        <KeepCard :keep="k" />
                    </div>
                </div>
            </section>
        </div>
    </div>
</template>


<script>
import { computed, reactive, onMounted } from 'vue';
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import { profilesService } from '../services/ProfilesService.js';
import Pop from "../utils/Pop.js";
import { logger } from '../utils/Logger.js';
import VaultCard from '../components/VaultCard.vue';
import KeepCard from '../components/KeepCard.vue';
export default {
    setup() {
        const route = useRoute();
        async function getProfile() {
            try {
                await profilesService.getProfile(route.params.id);
            }
            catch (error) {
                logger.error(error)
                Pop.error(error);
            }
        }
        async function getProfileVaults() {
            try {
                await profilesService.getProfileVaults(route.params.id);
            }
            catch (error) {
                console.error("[]", error);
                Pop.error(error);
            }
        }
        async function getProfileKeeps() {
            try {
                await profilesService.getProfileKeeps(route.params.id);
            }
            catch (error) {
                logger.error(error);
                Pop.error(error);
            }
        }
        onMounted(() => {
            getProfile();
            getProfileKeeps()
            getProfileVaults()
        });
        return {
            profile: computed(() => AppState.activeProfile),
            keeps: computed(() => AppState.keeps),
            vaults: computed(() => AppState.vaults),
        };
    },
    components: { VaultCard, KeepCard }
};
</script>


<style lang="scss" scoped>
.cover {
    background-size: cover;
    height: 25rem;
    background-position: center;
    position: relative;
}

.name {
    font-weight: 400;
}

img {
    max-width: 100px;
}

.stuff {
    margin-top: 13rem;
}

.vaults {
    width: 80vw;
    overflow-y: hidden;
}

.masonry {
    columns: 4;
}

.info {
    position: absolute;
    margin-top: 22rem;
    margin-left: 17rem;
    font-family: 'Oxygen';
    font-style: normal;
    font-size: 48px;
    line-height: 61px;
}

@media screen AND (max-width: 768px) {
    .masonry {
        columns: 2
    }

    .info {
        margin-top: 20rem;
        margin-left: .5rem;
    }
}
</style>