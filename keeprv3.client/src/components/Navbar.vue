<template>
  <nav class="navbar navbar-expand-lg   px-3 d-flex justify-content-between elevation-3 ">
    <div class="d-flex">
      <router-link class="" :to="{ name: 'Home' }">
        <button class="button btn border border-3 me-3 ">Home</button>
      </router-link>



      <div v-if="user.isAuthenticated">
        <div class="dropdown" v-if="!profilePage">
          <button class="btn btn border border-3 dropdown-toggle dropdown-toggle-split" type="button"
            data-bs-toggle="dropdown" aria-expanded="false">
            Create
          </button>
          <ul class="dropdown-menu text-center p-0">
            <li data-bs-toggle="modal" data-bs-target="#create-keep-modal" class="selectable">new keep</li>
            <li>
              <hr class="dropdown-divider">
            </li>
            <li data-bs-toggle="modal" data-bs-target="#create-vault-modal" class="selectable">new vault</li>
          </ul>
        </div>
      </div>
    </div>



    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo"
          src="data:image/png;base64,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"
          class="m-auto" height="60" />
      </div>
    </router-link>


    <Login class="hover" />
  </nav>
</template>

<script>
import { computed } from 'vue';
import { useRoute } from 'vue-router'
import { AppState } from '../AppState.js'
import Login from './Login.vue'
export default {
  setup() {
    const route = useRoute()
    return {
      profilePage: computed(() => route.name == "Profile"),
      user: computed(() => AppState.user),
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}



/* .bg-logo {
  background-color: gray;
} */

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }

}
</style>