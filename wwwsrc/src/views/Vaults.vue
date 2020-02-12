<template>
  <div class="vaults">
    <h1>This is the mother fucking Vault View mother fucker</h1>
    <div class="row">
      <div id="keepCards">
        <div class="col-3" v-for="userVault in userVaults" :key="userVault.Id">
          <div class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">{{vault.name}}</h5>
              <p class="card-text">Vault Desc</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vaults",
  mounted() {
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    userVaults() {
      return this.$store.state.userVaults;
    }
  }
};
</script>

<style>
</style>