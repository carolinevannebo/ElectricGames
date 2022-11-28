import { BrowserRouter, Routes, Route } from 'react-router-dom';
import MainPageHeader from './components/shared/MainPageHeader';
import { HomePage, CharacterPage, LocationPage } from './pages';
import { GamePage, GetAllGamesPage, GetGameByIdPage, GetGameByTitlePage, GetGamesByGenrePage, GetGamesByDeveloperPage, CreateNewGamePage, UpdateGamePage, DeleteGamePage  } from './pages/index';
import './styles/shared/App.css';
/*import GamePage from './pages/games/GamePage';
import GetAllGamesPage from './pages/games/GetAllGamesPage';
import GetGameByIdPage from './pages/games/GetGameByIdPage';*/

function App() {
  return (
    <BrowserRouter>
      <MainPageHeader />
      <main className='container'>
        <Routes>
          <Route path='/' element={<HomePage/>}></Route>
          <Route path='/games/*' element={<GamePage/>}>
            
              <Route path="games/get-all-games" element={<GetAllGamesPage/>}></Route>
              <Route path="games/get-game-by-id" element={<GetGameByIdPage/>}></Route>
              <Route path="games/get-game-by-title" element={<GetGameByTitlePage/>}></Route>
              <Route path="games/get-games-by-genre" element={<GetGamesByGenrePage/>}></Route>
              <Route path="games/get-games-by-developer" element={<GetGamesByDeveloperPage/>}></Route>
              <Route path="games/create-new-game" element={<CreateNewGamePage/>}></Route>
              <Route path="games/update-game" element={<UpdateGamePage/>}></Route>
              <Route path="games/delete-game" element={<DeleteGamePage/>}></Route>
            
          </Route>
          <Route path='/characters/*' element={<CharacterPage/>}></Route>
          <Route path='/locations/*' element={<LocationPage/>}></Route>
        </Routes>
      </main>
    </BrowserRouter>
  );
}

export default App;

//veldig mulig subroutes er redundant (inni game)
/**
 * <Route path='games/get-all-games' element={<GetAllGamesPage/>}></Route>
            <Route path='games/get-game-by-id' element={<GetGameByIdPage/>}></Route>
            <Route path='games/get-game-by-title' element={<GetGameByTitlePage/>}></Route>
            <Route path='games/get-games-by-genre' element={<GetGamesByGenrePage/>}></Route>
            <Route path='games/get-games-by-developer' element={<GetGamesByDeveloperPage/>}></Route>
            <Route path='games/create-new-game' element={<CreateNewGamePage/>}></Route>
            <Route path='games/update-game' element={<UpdateGamePage/>}></Route>
            <Route path='games/delete-game' element={<DeleteGamePage/>}></Route>
 */