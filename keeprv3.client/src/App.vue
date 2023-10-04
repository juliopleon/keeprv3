<template>
  <header>
    <Navbar class="desktop" />

  </header>
  <main>
    <router-view />
  </main>




  <Modal id="create-keep-modal">
    <CreateKeepModal />
  </Modal>

  <Modal id="create-vault-modal">
    <CreateVaultModal />
  </Modal>

  <!-- <Modal id="edit-vault-modal">
    <EditVaultModal />
  </Modal> -->

  <Modal id="edit-account-modal">
    <EditAccountModal />
  </Modal>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import KeepModel from "./components/KeepModel.vue"
import CreateKeepModal from "./components/CreateKeepModal.vue"
import Modal from "./components/Modal.vue"
import Navbar from './components/Navbar.vue'
import Pop from "./utils/Pop.js"
import CreateVaultModal from './components/CreateVaultModal.vue'
// import { accountService } from "./services/AccountService.js"
import EditAccountModal from "./components/EditAccountModal.vue"
// import EditVaultModal from "./components/EditVaultModal.vue"

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, Modal, KeepModel, CreateKeepModal, CreateVaultModal, EditAccountModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

main {
  background-color: #FEF6F0;
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
