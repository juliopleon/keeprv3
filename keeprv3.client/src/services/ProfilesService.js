import { AppState } from "../AppState.js";
import { api } from "./AxiosService.js"

class ProfilesService {
    async getProfile(id) {
        const res = await api.get(`api/profiles/${id}`)
        AppState.activeProfile = res.data
    }

    async getProfileKeeps(id) {
        const res = await api.get(`api/profiles/${id}/keeps`)
        AppState.keeps = res.data
    }

    async getProfileVaults(id) {
        const res = await api.get(`api/profiles/${id}/vaults`)
        AppState.vaults = res.data
        // console.log(AppState.vaults);
    }
}


export const profilesService = new ProfilesService()