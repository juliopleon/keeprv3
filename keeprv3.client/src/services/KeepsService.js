import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class KeepsService {
    async getKeeps() {
        const res = await api.get('api/keeps')
        logger.log(res.data)
        AppState.keeps = res.data;
    }

    async getActiveKeep(keepId) {
        const res = await api.get(`api/keeps/${keepId}`);
        logger.log("Getting keep", res.data)

        AppState.activeKeep = res.data;
        // if (vaultKeep) {
        //     AppState.activeKeep.vaultKeepId = vaultKeepId
        // }
        // if (keep != AppState.account.id) {
        //     AppState.activeKeep.views++
        // }
    }

    async createKeep(keepData) {
        const res = await api.post('/api/keeps', keepData)
        let keep = res.data
        AppState.keeps.unshift(keep)
    }

    async deleteKeep(id) {
        await api.delete(`api/keeps/${id}`)
        AppState.keeps = AppState.keeps.filter(k => k.id !== id)

    }

    // async deleteVaultKeep(id) {
    //     await api.delete(`api/vaultKeeps/${keepid}`)
    //     AppState.vaultKeeps = res.data
    // }

}


export const keepsService = new KeepsService()