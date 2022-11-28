import ILocation from "../../interfaces/locations/ILocation";
import '../../styles/shared/Item.css';

const LocationItem = ({
    id, name, image }: ILocation) => {

        return (
            <article>
                <div className="div-img">
                    <img src={`https://localhost:7132/images/locations/${image}`} alt={`${name}`} />
                </div>
                <div className="div-content">
                    <h3>{name} <span>({id})</span></h3>
                </div>
            </article>
        )
    }

export default LocationItem;