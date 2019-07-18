import orders from './templates/actionOrderProduct';
import product from './templates/navProduct';
import getValueCurrency from './templates/currency';
import addProduct from './templates/addProduct';
 // import statistics from './templates/statisticsProducts';

const contentDiv = document.getElementById('content');
getValueCurrency;
const routes = {
    '/': product,
    '/orders': orders,
    '/addProduct': addProduct,
  //  '/statistics': statistics,
};

const Router = {
    showContent: window.onpopstate = () => {
        contentDiv.innerHTML = routes[window.location.pathname];
    },
    keeptTrack: function (pathName) {
        window.history.pushState(
            {},
            pathName,
            window.location.origin + pathName
        );
        contentDiv.innerHTML = routes[pathName];
    },
    defaultContent: contentDiv.innerHTML = routes[window.location.pathname],
    toggle: document.getElementById('navigationBar').addEventListener('click', function toggle(event) {
        let id = event.target.id;
        if (id == "product") {
            Router.keeptTrack('/');
            removeAllChild("dashboardContent");
            removeAllChild("actionProduct"); 
            removeAllChild("pagination"); 
        }
        if (id == "orders") {
            Router.keeptTrack('/orders');
            removeAllChild("dashboardContent");
            removeAllChild("actionProduct"); 
            removeAllChild("pagination"); 
        }
        if (id == "addProduct") {
            Router.keeptTrack('/addProduct');
            removeAllChild("dashboardContent");
            removeAllChild("actionProduct"); 
            removeAllChild("pagination"); 
        }
        //if (id == "statistics") {
        //    Router.keeptTrack('/statistics');
        //    removeAllChild("dashboardContent");
        //    removeAllChild("actionProduct"); 
        //}
    })
}

function removeAllChild(id) {
    if (document.getElementById(id).childNodes.length > 0) {
        let element = document.getElementById(id);
        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }
    }
}

export default Router;
