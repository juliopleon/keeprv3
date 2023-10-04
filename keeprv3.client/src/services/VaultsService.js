import { AppState } from "../AppState.js";
import { router } from "../router.js";
import { api } from "./AxiosService.js"

class VaultsService {
    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        AppState.myVaults.unshift(res.data)
        AppState.activeVault = res.data
    }

    async removeVault(id) {
        const res = await api.delete(`/api/vaults/${id}`)
        if (res) {
            router.push({ name: 'Account' })
        }

    }

    async setVaultActive(id) {
        const res = await api.get(`api/vaults/${id}`)
        AppState.activeVault = res.data

    }

    async getKeepsInVault(id) {
        const res = await api.get(`api/vaults/${id}/keeps`)
        console.log(res.data, "keeps in vault");
        AppState.vaultKeeps = res.data

    }

    async addToVault(vaultData) {
        const res = await api.post(`api/vaultkeeps`, vaultData)
        AppState.activeKeep.kept++
        console.log(res.data);
        AppState.vaultKeepId = res.data
    }

    async editVault(vaultData, id) {
        const res = await api.put(`api/vaults/${id}`, vaultData)
        console.log(res.data);
        AppState.activeVault = res.data
    }


    async deleteVaultKeep(vkId) {

        const res = await api.delete(`api/vaultkeeps/${vkId}`)
        AppState.vaultKeeps = AppState.vaultKeeps.filter(k => k.vaultKeepId != vkId)
        // AppState.keeps = res.data

    }

    async getAllVaultKeeps() {
        const res = await api.get("api/vaultkeeps")
        AppState.vaultKeeps = res.data
    }

}

export const vaultsService = new VaultsService()