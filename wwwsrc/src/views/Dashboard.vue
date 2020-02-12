<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <div>hello</div>
    <form @submit.prevent="createKeep">
      <input type="text" placeholder="type NAME here" , v-model="newKeep.name" />
      <input type="text" placeholder="type DESCRIPTION here" , v-model="newKeep.description" />
      <button type="submit" class="btn btn-success"></button>
    </form>
  </div>
</template>

<script>
export default {
  name: "Dashboard",
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        isPrivate: Boolean
      }
    };
  },
  mounted() {},
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  }
};
</script>

<style></style>
