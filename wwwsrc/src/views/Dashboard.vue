<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <div>hello</div>
    <div class="col-12">
      <h3>Keep Form</h3>
      <modal name="addKeepModal">
        <form class="form" @submit.prevent="createKeep">
          <div class="form-group">
            <input type="text" name="Name" placeholder="type NAME here" v-model="newKeep.name" />
            <input
              type="text"
              name="Description"
              placeholder="type DESCRIPTION here"
              v-model="newKeep.description"
            />
            <input type="url" name="img" placeholder="Image Url" v-model="newKeep.img" />
            <input type="checkbox" name="isPrivate" v-model="newKeep.isPrivate" />
            <label for="checkbox">Private: {{newKeep.isPrivate}}</label>
            <button type="submit" class="btn btn-success">Create</button>
          </div>
        </form>
      </modal>
      <h3>Vault From</h3>
      <button @click="hideForm" type="button" class="btn btn-danger">oops</button>
      <button type="button" @click="showForm" class="btn btn-primary">Add</button>
      <div class="vaultForm">
        <form @submit.prevent="createVault">
          <input type="text" name="Name" placeholder="Name?" v-model="newVault.name" />
          >
          <input
            type="text"
            name="Description"
            placeholder="Description"
            v-model="newVault.description"
          />
          <button type="submit" class="btn btn-primary">here</button>
        </form>
      </div>
    </div>
    <h1>Private</h1>
    <div v-for="userKeep in userKeeps" :key="userKeep.id">
      {{userKeep.name}}
      <button class="btn btn-danger" @click="deleteKeep(userKeep)">Delete</button>
    </div>
    <h1>VaultKeeps</h1>
    {{vaultKeeps}}
  </div>
</template>

<script>
export default {
  name: "dashboard",
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: false,
        view: 0,
        shares: 0,
        keeps: 0
      },
      newVault: {
        name: "",
        description: ""
      }
    };
  },

  mounted() {
    this.$store.dispatch("getPrivateKeeps");
    this.$store.dispatch("getVaultKeeps");
  },
  methods: {
    createKeep() {
      let keep = { ...this.newKeep };
      this.$store.dispatch("createKeep", keep);
      this.newKeep = {
        name: "",
        description: "",
        img: "",
        isPrivate: false,
        view: 0,
        shares: 0,
        keeps: 0
      };
    },
    createVault() {
      let vault = { ...this.newVault };
      this.$store.dispatch("createVault", vault);
      this.newVault = {
        name: "",
        description: ""
      };
    },
    deleteKeep(userKeep) {
      this.$store.dispatch("deleteKeep", userKeep);
      this.$store.dispatch("getPrivateKeeps");
    },
    showForm() {
      this.$modal.show("addKeepModal");
    },
    hideForm() {
      this.$modal.hide("addKeepModal");
    }
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    }
  }
};
</script>

<style></style>
