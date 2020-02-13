<template>
  <div class="activeKeep container-fluid">
    <div class="row">
      <div class="col">
        <h1>the fuck</h1>
        {{activeKeep}}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keeps",
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {}
};
</script>

<style>
</style>