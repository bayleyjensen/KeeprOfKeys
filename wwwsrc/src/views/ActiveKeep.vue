<template>
  <div class="activeKeep container-fluid">
    <div class="row">
      <div class="card" style="width: 18rem;">
        <img :src="activeKeep.img" class="card-img-top" alt="..." />
        <div class="card-body">
          <h5 class="card-title">{{activeKeep.name}}</h5>
          <p class="card-text">{{activeKeep.description}}</p>
          <select name="userVault" id="options" @change="addVaultKeep(activeKeep.id,$event)">
            Select A Vault go ahead do it tomorrow
            <option value selected disabled>Select a Vault</option>
            <option
              v-for="userVault in userVaults"
              :key="userVault.id"
              :value="userVault.id"
            >{{userVault.name}}</option>
          </select>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keeps",
  data() {
    return {
      newVaultkeep: {
        vaultId: "",
        keepId: ""
      }
    };
  },
  mounted() {
    this.$store.dispatch("viewKeep");
    this.$store.dispatch("getUserVaults");
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    userVaults() {
      return this.$store.state.userVaults;
    }
  },
  methods: {
    addVaultKeep() {
      debugger;
      var option = document.getElementById("options");
      var vaultId = option.options[option.selectedIndex].value;
      var id = parseInt(vaultId, 10);
      this.newVaultkeep.keepId = this.activeKeep.id;
      this.newVaultkeep.vaultId = id;
      debugger;
      console.log(this.newVaultkeep);
      this.$store.dispatch("addVaultKeep", this.newVaultkeep);
    }
  }
};
</script>

<style>
</style>