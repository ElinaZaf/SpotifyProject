<template>
  <sign-in-form email="admin@demo.com" password="admin123"></sign-in-form>
</template>

<script>
import SignInForm from './Forms/SignInForm'

export default {
  name: 'SignIn1',
  components: { SignInForm },
  data: () => ({}),
  mounted () {
  },
  methods: {
  }
}
</script>
