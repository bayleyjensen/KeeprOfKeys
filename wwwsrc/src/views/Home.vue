<template>
  <div class="home">
    <div>
      <h1>Welcome Home</h1>
    </div>
    <div>
      <div class="row">
        <div id="keepCards">
          <div class="col-3" v-for="keep in keeps" :key="keep.id" :value="keep.id">
            <div class="card" style="width: 18rem;">
              <img :src="keep.img" class="card-img-top" />
              <div class="card-body">
                <h5 class="card-title">{{keep.name}}</h5>
                <p class="card-text">{{keep.description}}</p>
                <p class="keepStats">
                  <button>Keeps</button>
                  :{{keep.keeps}} |
                  <button>Shares</button>
                  :{{keep.shares}} |
                  <button @click="viewKeep(keep)">views</button>
                  :{{keep.views}}
                </p>
              </div>
              <button @click="deleteKeep(keep)" class="btn btn-danger">Delete</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    deleteKeep(keep) {
      this.$store.dispatch("deleteKeep", keep);
    },
    viewKeep(keep) {
      this.$store.dispatch("viewKeep", keep);
      this.$router.push({ path: "/keeps" });
    }
  }
};
</script>
