<template>
	<div>
		<h1>Teeeeeeeeeeeest</h1>

		<d-button @click="handleClick">Click me!</d-button>
		<d-button @click="handleClick">Click 2 me!</d-button>
		<d-alert dismissible theme="light" :show="showAlert" @alert-dismissed="siChuj">No co jeeeeeeeee </d-alert>
		<div>
			<d-navbar toggleable="lg">
				<d-navbar-nav :justified="true">
					<d-nav-item to="/">Turnaje</d-nav-item>
					<d-nav-item to="/">Rebríčky</d-nav-item>
					<d-nav-item to="/players">Hráči</d-nav-item>
				</d-navbar-nav>
			</d-navbar>
			<d-form-select v-model="selectedLanguage" :options="languages" class="language-select" />
		</div>
		<p>{{ $d(new Date(), "long") }}</p>
		<p>{{ $d(new Date(), "long", "sk") }}</p>
		<p>{{ $d(new Date(), "short", "sk") }}</p>
		<p>{{ $n(100, "currency", "en") }}</p>
		<p>{{ $n(100, "currency", "sk") }}</p>
		<p>{{ $n(0.53, "percent") }}</p>
	</div>
</template>

<script>
// import dButton from '../src/components/button/Button'
// import dAlert from '../src/components/alert/Alert'

export default {
  name: "Test",
  components: {
    // dButton,
    // dAlert
  },
  data() {
    return {
      showAlert: false,
      isDismisable: true,
      languages: ["EN", "SK"],
      selectedLanguage: null
    };
  },
  mounted() {
    this.selectedLanguage = this.languages[0];
  },
  methods: {
    handleClick() {
      this.showAlert = true;
    },
    siChuj() {
      this.showAlert = false;
    }
    // onNavClicked() {}
  }
};
</script>
