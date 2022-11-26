import { useEffect, useState, createContext, ReactNode } from "react";
import IGameContext from "../interfaces/games/IGameContext";
import IGame from "../interfaces/games/IGame";
import GameService from "../services/GameService";

export const GameContext = createContext<IGameContext | null>(null);

type Props = { children: ReactNode };

const GameProvider = ({ children }: Props) => {

    const [games, setGame] = useState<IGame[]>([]);

    useEffect(() => {
        getAllGamesFromService();
    }, []);

    const getAllGamesFromService = async () => {
        const response = await GameService.getAllGamesFromServer();
        setGame(response);
    }

    const getGameByIdFromService = async (id: number) => {
        const response = await GameService.getGameByIdFromServer(id);
        const array = [];
        array.push(response);
        setGame(array);
    }

    const getGameByTitleFromService = async (title: string) => {
        const response = await GameService.getGameByTitleFromServer(title);
        const array = [];
        array.push(response);
        setGame(array);
        //setGame(response);
    }

    const getGamesByGenreFromService = async (genre: string) => {
        const response = await GameService.getGamesByGenreFromServer(genre);
        const array = [];
        array.push(response);
        setGame(array);
        //setGame(response);
    }

    const getGamesByPlatformFromService = async (platform: string) => {
        const response = await GameService.getGamesByPlatformFromServer(platform);
        setGame(response);
    }

    const getGamesByDeveloperFromService = async (developer: string) => {
        const response = await GameService.getGamesByDeveloperFromServer(developer);
        const array = [];
        array.push(response);
        setGame(array);
        //setGame(response);
    }

    const putGameToService = async (game: IGame) => {
        const response = await GameService.putGameToServer(game);
        setGame(response);
    }

  return (
    <GameContext.Provider 
        value={{
            games, 
            getAllGamesFromService,
            getGameByIdFromService,
            getGameByTitleFromService,
            getGamesByGenreFromService,
            getGamesByPlatformFromService,
            getGamesByDeveloperFromService,
            putGameToService
        }}>
        {children}
    </GameContext.Provider>
  );

};

export default GameProvider;