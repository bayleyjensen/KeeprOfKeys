import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    userKeeps: [],
    userVaults: [],
    activeVault: {},
    vaultKeeps: [],
    activeKeep: {}
  },
  mutations: {
    setPublicKeeps(state, payload) {
      state.publicKeeps = payload;
    },
    setUserKeeps(state, payload) {
      state.userKeeps = payload;
    },
    setUserVaults(state, userVaults) {
      state.userVaults = userVaults;
    },
    setActiveKeep(state, payload) {
      state.activeKeep = payload;
    },
    setActiveVault(state, payload) {
      state.activeVault = payload;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setPublicKeeps", res.data);
      console.log("COMING FROM THE STORE", this.state.publicKeeps);
      console.log("COMING FROM THE STORE USERKEEPS", this.state.userKeeps);
    },
    async getPrivateKeeps({ commit, dispatch }) {
      let res = await api.get("keeps/User");
      commit("setUserKeeps", res.data);
      console.log("SHHHHH DONT TELL ANYONE");
    },
    async createKeep({ commit, dispatch }, keep) {
      try {
        let res = await api.post("Keeps", keep);
        dispatch("getPublicKeeps");
        console.log(this.state.userKeeps.length);
      } catch (error) {
        console.log("THERE WAS AN ERROR IN THE STORE");
      }
    },
    async createVault({ commit, dispatch }, vault) {
      try {
        let res = await api.post("Vaults", vault);
        console.log("Vault made this is from store");
      } catch (error) {
        console.log("THERE WAS AN ERROR IN THE STORE");
      }
    },
    async deleteKeep({ commit, dispatch }, keep) {
      let res = await api.delete("keeps/" + keep.id);
      dispatch("getPublicKeeps");
      console.log("DELETED KEEP WOOOHOOOOo!!");
    },
    async getUserVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      commit("setUserVaults", res.data);
      console.log("Got Vaults", this.state.userVaults);
    },
    async deleteVault({ commit, dispatch }, userVault) {
      let res = await api.delete("vaults/" + userVault.id);
      dispatch("getUserVaults");
      console.log("DELETED VAULT WOOOHOOOO!!");
    },
    async viewKeep({ commit, dispatch }, keep) {
      let res = await api.get("keeps/" + keep.id);
      debugger;
      commit("setActiveKeep", res.data);
      console.log("set active view", res.data);
    },
    async addVaultKeep({ commit, dispatch }, vaultKeep) {
      let res = await api.post("vaultkeeps", vaultKeep);
      dispatch("getKeepsByVaultId", vaultKeep.vaultId);
      console.log("FROM STORE VAULTKEEP", vaultKeep);
    },
    async getVaultKeeps({ commit, dispatch }, vaultId) {
      let res = await api.get("vaultkeeps/" + vaultId + "/keeps");
      commit("setVaultKeeps", res.data);
      console.log("SET VAULTKEEPS", res.data);
    },
    async viewVault({ commit, dispatch }, userVault) {
      debugger;
      let res = await api.get("vaults/" + userVault.id);
      commit("setActiveVault", res.data);
      console.log("Active Vault", res.data);
    }
  }
});
