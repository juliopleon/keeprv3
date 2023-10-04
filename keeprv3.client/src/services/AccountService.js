import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { Account } from "../models/Account.js"

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getAccountVaults() {
    const res = await api.get('account/vaults')
    console.log(res.data, "account vaults");
    AppState.myVaults = res.data

  }

  async getAccountKeeps() {
    // FIXME make a similar request but instead of getting the accounts keeps, get the profile keeps using the id of the account logged in.
    const res = await api.get('account/keeps')
    console.log(res.data, 'account keeps');
    AppState.myKeeps = res.data

  }

  async editAccount(formData) {
    const res = await api.put('/account', formData)
    AppState.account = new Account(res.data)
  }
}

export const accountService = new AccountService()
