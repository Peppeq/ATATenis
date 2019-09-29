<template>
	<div>
		<h1>WTF</h1>
		<h1>WTF</h1>
		<h1>WTF</h1>
		<h2>{{ jee }}</h2>
	</div>
</template>

<script lang="ts">
import { BaseComponentClass } from "../../common/BaseComponentClass";
import Component from "vue-class-component";

@Component
export default class Register extends BaseComponentClass {
	jee: string = "jejee";
}
</script>

<style></style>
