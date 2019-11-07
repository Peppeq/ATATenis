<template>
	<d-form-select v-model="selectedLanguage" :options="languages" :class="cssClass" @change="onChangeLang($event)" />
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";

@Component
export default class LanguageSelect extends Vue {
	@Prop({ default: "language-select" }) readonly cssClass!: string;

	languages: string[] = ["EN", "SK"];
	selectedLanguage: string = null;

	mounted() {
		this.selectedLanguage = this.languages[0];
	}
	onChangeLang(language: string): void {
		this.$i18n.locale = language.toLowerCase();
	}
}
</script>

<style lang="scss" scoped>
@import "@/styles/components/language-select.scss";
</style>
