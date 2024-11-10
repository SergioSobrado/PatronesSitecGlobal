import Axios from "axios";
import Utility from "@/utilities/functions/index";

export default {
    ConfigureInterceptors() {
        Axios.interceptors.response.use(undefined, (error) => {

        if(error?.code == "ERR_NETWORK" && Utility.tokenIsExpired()) {
            window.location.reload();
        }
        return Promise.reject(error);
        });
    },
};
