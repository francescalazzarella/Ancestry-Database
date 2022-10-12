const uri = 'items';
let todos = [];

function searchItems(searchTerm)
{
  let matchingSearches = [];
		searchTerm = searchTerm.toLowerCase;
		for(let i=0; i < this.todos.length; i++) {
			let name = this.data[i].name.toLowerCase();
			if (name.indexOf(searchTerm) >= 0) {
				matchingSearches.push(this.data[i]);
			}
		}
		this.todos = matchingSearches;
}

function getItems() {

  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
  const addNameTextbox = document.getElementById('add-name');
  const addDOBTextbox = document.getElementById('add-dob');
  const addBirthPlaceTextbox = document.getElementById('add-birthplace');
  const addBirthAnnotationTextbox = document.getElementById('add-birthannotation');
  const addDeathDateTextbox = document.getElementById('add-deathdate');
  const addDeathPlaceTextbox = document.getElementById('add-deathplace');
  const addCauseOfDeathTextbox = document.getElementById('add-causeofdeath');
  const addDeathAnnotationTextbox = document.getElementById('add-deathannotation');


  const item = {
    name: addNameTextbox.value,
    dob: addDOBTextbox.value,
    birthplace: addBirthPlaceTextbox.value,
    birthannotation: addBirthAnnotationTextbox.value,
    deathdate: addDeathDateTextbox.value,
    deathplace: addDeathPlaceTextbox.value,
    causeofdeath: addCauseOfDeathTextbox.value,
    deathannotation: addDeathAnnotationTextbox.value

  };

  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
      getItems();
      addNameTextbox.value = '';
      addDOBTextbox.value = '';
      addBirthPlaceTextbox.value = '';
      addBirthAnnotationTextbox.value = '';
      addDeathDateTextbox.value = '';
      addDeathPlaceTextbox.value = '';
      addCauseOfDeathTextbox.value = '';
      addDeathAnnotationTextbox.value = '';

    })
    .catch(error => console.error('Unable to add item.', error));
};

function deleteItem(event) {
  event.preventDefault();
  const providedId = event.target.dataset.itemId
  fetch(`${uri}/${providedId}`, {
    method: 'DELETE'
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(event) {
  event.preventDefault();
  
  console.dir(event)
 console.dir(event.target)
  console.log(event.target.dataset)
  const providedId = event.target.dataset.itemId

  const item = todos.find(item => item.id === providedId);


  document.getElementById('edit-name').value = item.name;
  document.getElementById('edit-dob').value = item.dob;
  document.getElementById('edit-birthplace').value = item.birthPlace;
  document.getElementById('edit-birthannotation').value= item.birthAnnotation;
  document.getElementById('edit-deathdate').value = item.deathDate;
  document.getElementById('edit-deathplace').value = item.deathPlace;
  document.getElementById('edit-causeofdeath').value = item.causeOfDeath;
  document.getElementById('edit-deathannotation').value = item.deathAnnotation;
  document.getElementById('edit-id').value = item.id;
  document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
  const itemId = document.getElementById('edit-id').value;
  const item = {
    id: parseInt(itemId, 10),
    name: document.getElementById('edit-name').value.trim(),
    dob: document.getElementById('edit-dob').value,
    birthPlace: document.getElementById('edit-birthplace').value,
    birthannotation: document.getElementById('edit-birthannotation').value,
    deathdate: document.getElementById('edit-deathdate').value,
    deathplace: document.getElementById('edit-deathplace').value,
    causeofdeath: document.getElementById('edit-causeofdeath').value,
    deathannotation: document.getElementById('edit-deathannotation').value
  };
  fetch(`${uri}/${itemId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to update item.', error));
  closeInput();
  return false;
}

function closeInput() {
  document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
  //if statement (ternary statement) condition ? if : else
  const name = (itemCount === 1) ? 'profile' : 'profiles';
  // What the ternary statement is doing:
  // let name;
  // if(itemCount === 1){
  //   name = 'catalog'
  // }else{
  //   name = 'catalogs'
  // }

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
  const tBody = document.getElementById('todos');
  tBody.innerHTML = '';

  _displayCount(data.length);

  const button = document.createElement('button');

  data.forEach(item => {

    let isCompleteCheckbox = document.createElement('input');
    isCompleteCheckbox.type = 'checkbox';
    isCompleteCheckbox.disabled = true;
    isCompleteCheckbox.checked = item.isComplete;

    // console.dir(isCompleteCheckbox)
    // console.log(isCompleteCheckbox)

    let editButton = button.cloneNode(false);
    editButton.innerText = 'Edit';
    editButton.dataset.itemId = item.id;

    editButton.addEventListener('click', displayEditForm)


    let deleteButton = button.cloneNode(false);
    deleteButton.innerText = 'Delete';
    deleteButton.dataset.itemId = item.id;
    deleteButton.addEventListener('click', deleteItem)


    let tr = tBody.insertRow();

    let td1 = tr.insertCell(0);
    let textNode = document.createTextNode(item.name);
    td1.appendChild(textNode);

    let td2 = tr.insertCell(1);
    let dobNode = document.createTextNode(item.dob);
    td2.appendChild(dobNode);

    let td3 = tr.insertCell(2);
    let birthPlaceNode = document.createTextNode(item.birthPlace);
    td3.appendChild(birthPlaceNode);

    let td4 = tr.insertCell(3);
    let birthAnnotationNode = document.createTextNode(item.birthAnnotation);
    td4.appendChild(birthAnnotationNode);

    let td5 = tr.insertCell(4);
    let deathDateNode = document.createTextNode(item.deathDate);
    td5.appendChild(deathDateNode);

    let td6 = tr.insertCell(5);
    let deathPlaceNode = document.createTextNode(item.deathPlace);
    td6.appendChild(deathPlaceNode);

    let td7 = tr.insertCell(6);
    let causeOfDeathNode = document.createTextNode(item.causeOfDeath);
    td7.appendChild(causeOfDeathNode);

    let td8 = tr.insertCell(7);
    let deathAnnotationNode = document.createTextNode(item.deathAnnotation);
    td8.appendChild(deathAnnotationNode);

    let td9 = tr.insertCell(8);
    td9.appendChild(editButton);

    let td10 = tr.insertCell(9);
    td10.appendChild(deleteButton);
  });

  todos = data;

  
}


var slidePosition = 0;
SlideShow();

function SlideShow() {
  var i;
  var slides = document.getElementsByClassName("Containers");
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  slidePosition++;
  if (slidePosition > slides.length) {slidePosition = 1}
  slides[slidePosition-1].style.display = "block";
  setTimeout(SlideShow, 5000);
} 

//---------------------------------------------------------------Search Function//
/*function searchItems(searchTerm) {
  let searchTerm = document.getElementById("searchTerm");
  let filter = searchTerm.value.toUpperCase();
  let todos = document.getElementById("todos");
  for (i = 0; i < todos.length; i++) {
      if (searchTerm == todos[i].toUpperCase){
        return todos[i]
      }
  }} */