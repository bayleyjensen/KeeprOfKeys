import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Vaults from "./views/Vaults.vue";
// @ts-ignore
import ActiveKeep from "./views/ActiveKeep.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
// @ts-ignore
import ActiveVault from "./views/ActiveVault.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard
    },
    {
      path: "/vaults",
      name: "vaults",
      component: Vaults,
      beforeEnter: authGuard
    },
    {
      path: "/keeps",
      name: "keeps",
      component: ActiveKeep,
      beforeEnter: authGuard
    },
    {
      path: "/ActiveVault",
      name: "ActiveVault",
      component: ActiveVault,
      beforeEnter: authGuard
    }
  ]
});
