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
    setPublicKeeps(state, publicKeeps) {
      state.publicKeeps = [];
      state.publicKeeps.push(...publicKeeps);
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = [];
      state.userKeeps.push(...userKeeps);
    },
    setUserVaults(state, userVaults) {
      state.userVaults = [];
      state.userVaults.push(...userVaults);
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async GetPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setPublicKeeps", res.data);
      console.log("COMING FROM THE STORE", this.state.publicKeeps);
    },
    async CreateKeep({ commit, dispatch }, keep) {
      try {
        let res = await api.post("Keeps", keep);
        dispatch("GetPublicKeeps");
      } catch (error) {
        console.log("THERE WAS AN ERROR IN THE STORE");
      }
    }
  }
});
