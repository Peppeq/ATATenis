<template>
  <div>
    <div class="container">
      <d-row class="login-row justify-content-center align-items-center">
        <d-card class="login-card">
          <d-card-body>
            <h2>{{ $t("login") }}</h2>
            <form @submit.prevent="handleSubmit">
              <div class="form-group">
                <label for="username">{{ $t("username") }}</label>
                <input v-model="username" type="text" name="username" class="form-control" :class="{ 'is-invalid': submitted && !username }">
                <div v-show="submitted && !username" class="invalid-feedback">
                  {{ $t("usernameRequired") }}
                </div>
              </div>
              <div class="form-group">
                <label for="password">{{ $t("password") }}</label>
                <input v-model="password" type="password" name="password" class="form-control" :class="{ 'is-invalid': submitted && !password }">
                <div v-show="submitted && !password" class="invalid-feedback">
                  {{ $t("passwordRequired") }}
                </div>
              </div>
              <div class="form-group">
                <loading-button :size="null" :text="$t('login')" :show-loading="status.loggedIn" />
              </div>
            </form>
          </d-card-body>
        </d-card>
      </d-row>
    </div>
  </div>
</template>

<script lang="ts">
import Component from "vue-class-component";
import { BaseComponentClass } from "../../common/BaseComponentClass";
import { AccountStateStatus } from "../../store/modules/account";
import store from "@/store/indexx";

// import { mapActions, ActionMethod } from "vuex";
@Component
export default class LoginViewClass extends BaseComponentClass {
  submitted = false;
  username: string = null;
  password: string = null;
  status: AccountStateStatus = {
    loggedIn: false,
    loggingIn: false,
    registering: false
  };
  isBtnDisabled = false;
  showLoading = false;

  computed() {
    this.status = store.state.accountModule.status;
    this.isBtnDisabled = store.state.accountModule.status.loggingIn == true;
    // status poriesit ako ho budem trackovat, logovanie poriesit ci do consoli len alebo do filu
  }

  handleSubmit() {
    this.submitted = true;
    if (this.username && this.password) {
      store.dispatch.accountModule.login({
        Username: this.username,
        Password: this.password,
        Token: null
      });
    }
  }
}
</script>
<style lang="scss" scoped>
@import "@/styles/views/user/login.scss";
</style>
