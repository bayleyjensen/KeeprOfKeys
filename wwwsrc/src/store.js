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
    activeVault: [],
    vaultKeeps: []
  },
  mutations: {
    setPublicKeeps(state, payload) {
      state.publicKeeps = payload;
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps;
    },
    setUserVaults(state, userVaults) {
      state.userVaults = userVaults;
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
    },
    async GetPrivateKeeps({ commit, dispatch }) {
      let res = await api.get("keeps/userKeeps");
      commit("setUserKeeps", res.data);
      console.log("SHHHHH DONT TELL ANYONE");
    },
    async createKeep({ commit, dispatch }, keep) {
      try {
        let res = await api.post("Keeps", keep);
        dispatch("GetPublicKeeps");
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
      // dispatch("UserKeeps");
      console.log("DELETED KEEP WOOOHOOOO!!");
    },
    async getUserVaults({ commit, dispatch }) {
      let res = await api.get("vaults");
      commit("seUserVaults", res.data);
      console.log("Got Vaults", this.state.userVaults);
    }
  }
});
