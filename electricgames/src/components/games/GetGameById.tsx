import { useContext, useState, ChangeEvent, useEffect} from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import { GameContext } from "../../contexts/GameContext";
import GameList from "./GameList";

const GetGameById = () => {
    
    const { getGameByIdFromService } = useContext(GameContext) as IGameContext;
    const [id, setId] = useState<number>(1001);
    
    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const id = event.currentTarget.value;
        setId(parseInt(id));
    }

    useEffect(() => {
        getGameByIdFromService(id);
    }, [id, getGameByIdFromService]);

    return (
        <section className="page-content-choice">
            <h3>Find Game By ID</h3>

            <div>
                <label htmlFor="id">Enter Game ID: </label>
                <input type="number" id="id" name="id" value={id} onChange={handleChange} />
            </div>
            
            <section className="page-result">
                <GameList />
            </section>
        </section>
    )
}

export default GetGameById;