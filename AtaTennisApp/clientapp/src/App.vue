<template>
	<div id="app">
		<app-layout>
			<router-view />
		</app-layout>
		<notifications position="top center">
			<!-- <template slot="body" slot-scope="props">
				<div>
					<a class="title">
						{{ props.item.title }}
					</a>
					<a class="close" @click="props.close">
						<i class="far fa-times-circle"></i>
					</a>
					<div v-html="props.item.text"></div>
				</div>
			</template> -->
		</notifications>
	</div>
</template>
<script lang="ts">
import Vue from "vue";

export default class App extends Vue {
	created() {
		// let fontawesome = document.createElement("script");
		// fontawesome.setAttribute("src", "https://kit.fontawesome.com/a8081aacd9.js");
		// fontawesome.setAttribute("crossorigin", "anonymous");
		// document.head.appendChild(fontawesome);
	}

	// @Ref() provider!: InstanceType<typeof ValidationProvider>;
}
</script>
