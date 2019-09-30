<template>
	<d-button :size="size"><Spinner v-if="showLoading" name="circle" color="white" />{{ text }}</d-button>
</template>

<script lang="ts">
import Component from "vue-class-component";
import { Prop } from "vue-property-decorator";
import Vue from "vue";

@Component
export default class LoadingButton extends Vue {
	@Prop(String) text!: string;
	@Prop(String) size: string;
	@Prop(Boolean) showLoading!: boolean;
}
</script>

<style>
.sk-spinner {
	width: 20px !important;
	height: 20px !important;
	position: relative;
	float: right;
	margin-left: 10px;
}
</style>
