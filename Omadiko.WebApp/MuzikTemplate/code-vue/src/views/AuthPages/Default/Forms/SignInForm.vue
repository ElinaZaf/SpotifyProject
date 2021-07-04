<template>
  <ValidationObserver ref="form" v-slot="{ handleSubmit }">
    <div class="sign-in-page-data">
      <div class="sign-in-from w-100 pt-5 m-auto">
        <h1 class="mb-3 text-center">Sign in</h1>
        <form class="mt-4" novalidate @submit.prevent="handleSubmit(onSubmit)">
          <ValidationProvider vid="email" name="E-mail" rules="required|email" v-slot="{ errors }">
            <div class="form-group">
              <label for="emailInput">Email address</label>
              <input type="email" :class="'form-control mb-0' +(errors.length > 0 ? ' is-invalid' : '')"
                    id="emailInput" aria-describedby="emailHelp"
                    v-model="user.email" placeholder="Enter email" required>
              <div class="invalid-feedback">
                <span>{{ errors[0] }}</span>
              </div>
            </div>
          </ValidationProvider>
          <ValidationProvider vid="password" name="Password" rules="required" v-slot="{ errors }">
            <div class="form-group">
              <label for="passwordInput">Password</label>
              <input type="password"  :class="'form-control mb-0' +(errors.length > 0 ? ' is-invalid' : '')"
                    id="passwordInput"
                    v-model="user.password" placeholder="Password" required>
              <div class="invalid-feedback">
                <span>{{ errors[0] }}</span>
              </div>
            </div>
          </ValidationProvider>
          <div class="sign-info">
            <button type="submit" class="btn btn-primary mb-2">Sign in</button>
            <span class="dark-color d-block line-height-2">
              Don't have an account?
              <router-link to="/auth/sign-up1" >
                Sign up
              </router-link>
            </span>
          </div>
          <div class="d-inline-block w-100">
            <div class="custom-control custom-checkbox d-inline-block mt-2 pt-1">
              <input type="checkbox" class="custom-control-input" id="customCheck1">
              <label class="custom-control-label" for="customCheck1">Remember Me</label>
            </div>
          </div>
        </form>
      </div>
    </div>
    <div class="mt-2">
      <div class="d-flex justify-content-center links">
        Don't have an account?
        <router-link to="/auth/sign-up1" class="ml-2">
          Sign Up
        </router-link>
      </div>
      <div class="d-flex justify-content-center links">
        <router-link to="/auth/password-reset1">
          Forgot your password?
        </router-link>
      </div>
    </div>
  </ValidationObserver>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  name: 'SignInForm',
  components: { },
  props: ['email', 'password'],
  data: () => ({
    user: {
      email: '',
      password: ''
    }
  }),
  mounted () {
    this.user.email = this.$props.email
    this.user.password = this.$props.password
  },
  computed: {
    ...mapGetters({
      stateUsers: 'Setting/usersState'
    })
  },
  methods: {
    onSubmit () {
      let selectedUser = this.stateUsers.find(user => {
        return (user.email === this.user.email && user.password === this.user.password)
      }) || null
      if (selectedUser) {
        this.$store.dispatch('Setting/authUserAction', {
          auth: true,
          user: {
            id: selectedUser.uid,
            name: selectedUser.name,
            mobileNo: null,
            email: selectedUser.email,
            profileImage: null
          }
        })
        localStorage.setItem('user', JSON.stringify(selectedUser))
        localStorage.setItem('access_token', selectedUser.token)
        this.$router.push({ name: 'dashboard.home-1' })
      }
    }
  }
}
</script>
