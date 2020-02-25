<template>
  <div class="activeVault">
    <div>
      <div>Here is the Active Vault View (VUE)</div>
      {{ activeVault }}
    </div>
  </div>
</template>

<script>
export default {
  name: "activeVault",
  mounted() {
    this.$store.dispatch("viewVault");
    this.$store.dispatch("getPublicKeeps");
    this.$store.dispatch("getPrivateKeeps");
  },
  computed: {
    activeVault() {
      this.$store.state.activeVault;
    },
    publicKeeps() {
      this.$store.state.publicKeeps;
    },
    userKeeps() {
      this.$store.state.userKeeps;
    }
  }
};
</script>

<style>
</style>