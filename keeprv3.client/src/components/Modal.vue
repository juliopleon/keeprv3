<template>
    <div class="modal fade" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-xl">
            <div class="modal-content">


                <slot>

                </slot>

            </div>
        </div>
    </div>
</template>


<script>
// import { AppState } from '../AppState';
// import { computed, reactive, onMounted } from 'vue';
export default {
    setup() {
        return {}
    }
};
</script>


<style lang="scss" scoped>
.modal {
    // background: rgb(81, 51, 101);
    background: linear-gradient(34deg, rgb(146, 106, 173) 0%, rgba(253, 29, 29, 0.46544555322128855) 50%, rgb(167, 128, 74) 100%);
    backdrop-filter: blur(3px);
}
</style>