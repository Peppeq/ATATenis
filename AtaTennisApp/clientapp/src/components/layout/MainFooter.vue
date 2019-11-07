<template>
	<footer class="main-footer d-flex p-2 px-3 bg-white border-top mt-4">
		<div class="container-fluid m-auto">
			<div class="row">
				<span class="copyright ml-auto my-auto mr-2">{{ copyright }}</span>
			</div>
		</div>
	</footer>
</template>

<script>
export default {
	name: "MainFooter",
	props: {
		/**
		 * The copyright information.
		 */
		copyright: {
			type: String,
			default: "Copyright © 2019 Peppeq"
		}
	}
};
</script>
<style lang="scss" scoped></style>
