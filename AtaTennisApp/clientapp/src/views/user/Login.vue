<template>
	<div>
		<d-card>
			<d-card-body>
				<h2>Login</h2>
				<form @submit.prevent="handleSubmit">
					<div class="form-group">
						<label for="username">Username</label>
						<input
							v-model="username"
							type="text"
							name="username"
							class="form-control"
							:class="{ 'is-invalid': submitted && !username }"
						/>
						<div v-show="submitted && !username" class="invalid-feedback">Username is required</div>
					</div>
					<div class="form-group">
						<label htmlFor="password">Password</label>
						<input
							v-model="password"
							type="password"
							name="password"
							class="form-control"
							:class="{ 'is-invalid': submitted && !password }"
						/>
						<div v-show="submitted && !password" class="invalid-feedback">Password is required</div>
					</div>
					<div class="form-group">
						<loading-button :size="null" :text="loginText" :show-loading="status.loggedIn" />
					</div>
				</form>
			</d-card-body>
		</d-card>
	</div>
</template>

<script lang="ts">
import Component from "vue-class-component";
import { BaseComponentClass } from "../../common/BaseComponentClass";
import { AccountStateStatus } from "../../store/modules/account";
import { i18n } from "@/plugins/i18n";

@Component
export default class LoginViewClass extends BaseComponentClass {
	submitted: boolean = false;
	username: string = null;
	password: string = null;
	status: AccountStateStatus = { loggedIn: false, loggingIn: false, registering: false };
	isBtnDisabled: boolean = false;
	loginText: string = i18n.t("login").toString();
	showLoading: boolean = false;

	computed() {
		this.status = this.$store.state.AccountState.AccountStateStatus;
		this.isBtnDisabled = this.$store.state.AccountState.AccountStateStatus == AccountStateStatus.loggingIn;
		// status poriesit ako ho budem trackovat, logovanie poriesit ci do consoli len alebo do filu
	}

	handleSubmit() {
		this.submitted = true;
		if (this.username && this.password) {
			this.$store.dispatch("accountModule/login", {
				Username: this.username,
				Password: this.password,
				Token: null
			});
		}
	}
}
</script>
