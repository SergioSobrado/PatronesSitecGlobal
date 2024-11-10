import axios from "axios";

export default {
    async $GetString() {
        return axios.get<string>("/api/Test/GetStrings");
    },
};