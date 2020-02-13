<template>
  <div class="activeKeep container-fluid">
    <div class="row">
      <div class="col">{{activeKeep}}</div>
      <div class="row">
        <div class="col">
          <div class="dropdown">
            <select name="vault" id="options">
              Select A Vault
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
    this.$store.dispatch("setActiveKeep");
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    userVaults() {
      return this.$store.state.userVaults;
    }
  },
  methods: {}
};
</script>

<style>
</style>