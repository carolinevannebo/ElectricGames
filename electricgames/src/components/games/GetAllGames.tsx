import { useContext, useEffect } from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import {GameContext} from "../../contexts/GameContext";
import GameList from "./GameList";

const GetAllGames = () => {

    const { games, getAllGamesFromService } = useContext(GameContext) as IGameContext;

    useEffect(() => {
        getAllGamesFromService();
    }, [getAllGamesFromService]);

    return (
        <section className="page-content-choice">
            
            <p>Number of games in the database: {games.length}</p>
            <section className="page-result">
                <GameList />
            </section>
        </section>
    )
}

export default GetAllGames