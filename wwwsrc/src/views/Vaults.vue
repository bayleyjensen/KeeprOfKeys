<template>
  <div class="vaults">
    <h1>This is the mother fucking Vault View mother fucker</h1>
    <div class="row">
      <div id="keepCards">
        <div class="col-3" v-for="userVault in userVaults" :key="userVault.Id">
          <div class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">{{userVault.name}}</h5>
              <p class="card-text">{{userVault.description}}</p>
              <button @click="deleteVault(userVault)" class="btn btn-danger">Delete</button>
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
  methods: {
    deleteVault(userVault) {
      this.$store.dispatch("deleteVault", userVault);
    }
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