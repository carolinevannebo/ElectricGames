import axios from "axios";

const LocationService = (
    () => {
        const apiEndpoint = "https://localhost:7132/api";
        const locationEndPoint = `${apiEndpoint}/location`;

        const getAllLocationsFromServer = async () => {
            const result = await axios.get(locationEndPoint);
            return result.data;
        }

        const getLocationByIdFromServer = async (id: number) => {
            const result = await axios.get(`${locationEndPoint}/${id}`);
            return result.data;
        }

        const getLocationByNameFromServer = async (name: string) => {
            const result = await axios.get(`${locationEndPoint}/name/${name}`);
            return result.data;
        }

        return {
            getAllLocationsFromServer,
            getLocationByIdFromServer,
            getLocationByNameFromServer
        }
    }
)();

export default LocationService;