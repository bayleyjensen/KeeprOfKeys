<template>
  <div class="vaults">
    <h1>Vaults</h1>
    <div class="row">
      <div id="keepCards">
        <div class="col-3" v-for="userVault in userVaults" :key="userVault.Id">
          <div class="card" style="width: 18rem;">
            <div class="card-body">
              <h5 class="card-title">{{userVault.name}}</h5>
              <p class="card-text">{{userVault.description}}</p>
              <button @click="deleteVault(userVault)" class="btn btn-danger">Delete</button>
            </div>
            <select
              name="selectKeep"
              id="KeepOptions"
              @change="addVaultKeep(this.userVault.id,$event)"
            >
              <option value selected disabled>Select a Keep</option>
              <option v-for="keep in keeps" :key="keep.id" :value="keep.id">{{keep.name}}</option>
            </select>
            <button type="button" class="btn btn-secondary" @click="viewVault(userVault)">View</button>
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
    },
    viewVault(userVault) {
      debugger;
      this.$store.dispatch("viewVault", userVault);
      this.$router.push({ path: "/ActiveVault" });
    }
  },
  computed: {
    userVaults() {
      return this.$store.state.userVaults;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    }
  }
};
</script>

<style>
</style>