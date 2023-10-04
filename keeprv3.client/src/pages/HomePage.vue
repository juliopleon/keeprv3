<template>
  <section class="container-fluid">
    <div class="masonry-style my-4">
      <div v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
      </div>
    </div>
  </section>
</template>

<script>
import { onMounted, computed } from 'vue'
import KeepCard from '../components/KeepCard.vue';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js';
import { AppState } from '../AppState.js';

export default {
  setup() {
    async function getKeeps() {
      try {
        await keepsService.getKeeps()
      } catch (error) {
        Pop.error(error.message)
      }
    }

    onMounted(() => {
      getKeeps();
    });
    return {
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account)
    };
  },
  components: { KeepCard }
}
</script>

<style scoped lang="scss">
.masonry-style {
  columns: 4;
}

@media screen AND (max-width: 770px) {
  .masonry-style {
    columns: 2
  }
}
</style>
