import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},


  keeps: [],
  activeKeep: null,
  vaults: [],
  activeVault: null,
  vaultKeeps: [],
  activeVaultKeep: null,
  myVaults: [],
  myKeeps: [],
  myVaultKeeps: [],

  activeProfile: null,
})
