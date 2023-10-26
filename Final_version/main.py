import impy
import pandas as pd
from sklearn.impute import KNNImputer
from sklearn.preprocessing import MinMaxScaler
from sklearn.preprocessing import StandardScaler
from sklearn.decomposition import PCA
from mpl_toolkits.mplot3d import Axes3D
import impyute as impy
from fancyimpute import KNN
from sklearn.cluster import AgglomerativeClustering
from scipy.cluster.hierarchy import dendrogram
from scipy.stats import f_oneway
import matplotlib
matplotlib.use('Qt5Agg')
import matplotlib.pyplot as plt
import seaborn as sns
import numpy as np

#load data
df = pd.read_csv("C:/Users/Matteo/Desktop/Lab_ehealth/Data_project/Data_reduction.csv")
print(df)
df = df.drop('gender', axis=1)
df = df.drop('marital', axis=1)
# df = df.drop('ccs_4', axis = 1)
# df = df.drop('ccs_8', axis = 1)
# df = df.drop('ccs_10', axis = 1)
# df = df.drop("income" , axis=1)
# df = df.drop('heas_1', axis=1)
# df = df.drop('heas_2', axis=1)
# df = df.drop('heas_3', axis=1)
# df = df.drop('heas_4', axis=1)
# df = df.drop('heas_5', axis=1)
# df = df.drop('heas_6', axis=1)
# df = df.drop('heas_7', axis=1)
# df = df.drop('heas_8', axis=1)
# df = df.drop('heas_9', axis=1)
# df = df.drop('heas_10', axis=1)
# df = df.drop('heas_11', axis=1)
# df = df.drop('heas_12', axis=1)
# df = df.drop('heas_13', axis=1)

#missing values
total_missing_count = df.isnull().sum().sum()
print("num dati mancanti:", total_missing_count)
print(df.describe())

# Istogrammi delle variabili numeriche
df.hist(figsize=(16, 10))  # Imposta la dimensione del grafico a seconda delle tue preferenze
plt.suptitle("Istogrammi delle variabili")
plt.show()

# Matrice di correlazione tra le variabili
correlation_matrix = df.corr()
plt.figure(figsize=(12, 8))  # Imposta la dimensione del grafico a seconda delle tue preferenze
sns.heatmap(correlation_matrix, annot=True, cmap='coolwarm')
plt.title('Matrice di correlazione tra variabili')
plt.show()

#KNN=3 per interpolare dati mancanti
imputer = KNN(k=3)  # Imposta il valore di k desiderato
imputed_df = imputer.fit_transform(df)
# Converte l'array risultante in un DataFrame
imputed_df = pd.DataFrame(imputed_df, columns=df.columns)
print(imputed_df)
total_missing_count = imputed_df.isnull().sum().sum()
print("num dati mancanti:", total_missing_count)

# MinMaxScaler
scaler = MinMaxScaler()
# Standardizza le colonne del DataFrame
standardized_data = pd.DataFrame(scaler.fit_transform(imputed_df), columns=df.columns)
# Stampa il DataFrame standardizzato
print(standardized_data)
print(standardized_data.describe())

#PCA
pca = PCA(svd_solver='full', whiten=False)
# Adatta il modello ai dati
pca.fit(standardized_data)
# Percentuale di varianza spiegata per ciascuna componente principale
explained_variance_ratio = pca.explained_variance_ratio_
# Plot della percentuale di varianza spiegata
plt.figure(figsize=(6, 4))
plt.bar(range(1, len(explained_variance_ratio) + 1), explained_variance_ratio)
plt.xlabel('Componente Principale')
plt.ylabel('Percentuale di Varianza Spiegata')
plt.title('Percentuale di Varianza Spiegata per Componenti Principali')
plt.show()

# Soglia desiderata
threshold = 0.80

# Calcola la varianza cumulativa
cumulative_variance = np.cumsum(explained_variance_ratio)

# Trova il numero di componenti principali per superare o raggiungere la soglia
num_components = np.argmax(cumulative_variance >= threshold) + 1
print(f"Numero di componenti principali per raggiungere la soglia del {threshold * 100}% di varianza spiegata: {num_components}")

# PCA
pca = PCA(n_components = num_components, svd_solver='full', whiten=False)
principal_components = pca.fit_transform(standardized_data)

#Plot pesi PCA
feature_names = standardized_data.columns.tolist()
pca_components = pca.components_
# Creazione di un DataFrame per una migliore visualizzazione
pca_weights_df = pd.DataFrame(pca_components, columns=feature_names, index=[f'PC {i+1}' for i in range(num_components)])
# Visualizza i pesi delle componenti principali
print(pca_weights_df)
n_components, n_features = pca_components.shape

# Crea un istogramma per ciascuna componente principale
# for i in range(n_components):
#    plt.figure(figsize=(8, 6))
#    plt.bar(range(n_features), pca_components[i, :], tick_label=feature_names)
#    plt.xlabel('Feature')
#    plt.ylabel(f'Peso PC {i + 1}')
#    plt.title(f'Pesi della PC {i + 1} per ciascuna feature')
#    plt.xticks(range(len(feature_names)), feature_names, rotation=90)
#    plt.tight_layout()
#    plt.show()

# Plot del dendrogramma
from scipy.cluster.hierarchy import linkage
linkage_matrix = linkage(principal_components, method='ward')
dendrogram(linkage_matrix)
plt.title('Dendrogramma del Clustering Gerarchico')
plt.show()

# Clustering gerarchico
n_clusters = 3
agg_clustering = AgglomerativeClustering(n_clusters, linkage='ward')
cluster_labels = agg_clustering.fit_predict(principal_components)

# Crea un DataFrame con solo le prime 3 componenti principali e la colonna Cluster
principal_df_3d = pd.DataFrame(data=principal_components[:, :3], columns=['PC1', 'PC2', 'PC3'])
principal_df_3d['Cluster'] = cluster_labels
print(principal_df_3d.head())

# Definisci una lista di colori per ciascun valore della colonna 'Cluster'
colori = ['red', 'blue', 'green', 'orange', 'purple', 'cyan']

# Crea una figura 3D
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
for index, row in principal_df_3d.iterrows():
    x = row['PC1']
    y = row['PC2']
    z = row['PC3']
    cluster = int(row['Cluster'])
    colore = colori[cluster]
    ax.scatter(x, y, z, c=colore, label=f'Cluster {cluster}')
ax.set_xlabel('PC1')
ax.set_ylabel('PC2')
ax.set_zlabel('PC3')
plt.show()

# Test ANOVA per la significatività dei cluster
p_values = {}
for column in df.columns:
    groups = [df[column][cluster_labels == i] for i in range(n_clusters)]
    f_statistic, p_value = f_oneway(*groups)
    p_values[column] = p_value
for variable, p_value in p_values.items():
    print(f'P-value per {variable}: {p_value}')



#crea colonna nel dataframe con i cluster
df_labeled = imputed_df
df_labeled['Cluster'] = cluster_labels
print(df_labeled.head(5))

# #crea il database con i cluster non standardizzato e salva su .csv
# df_labeled_non_standardized = imputed_df
# df_labeled_non_standardized['Cluster'] = cluster_labels
# df_labeled_non_standardized.to_csv('C:/Users/Matteo/Desktop/Lab_ehealth/Data_project/Data_labeled.csv', index=False)

#separare i dataframe con i diversi cluster
for cluster_id in range(n_clusters):
    df_cluster = df_labeled[df_labeled['Cluster'] == cluster_id]
    df_cluster = df_cluster.drop('Cluster', axis=1)
    globals()[f'df_cluster{cluster_id}'] = df_cluster

df_labeled=df_labeled.drop('ccs_8', axis = 1)
df_labeled=df_labeled.drop('ccs_10', axis = 1)

# Istogrammi delle variabili per cluster
for cluster_id in range(n_clusters):
    cluster_name = f"cluster_{cluster_id}"
    df_cluster = df_labeled[df_labeled['Cluster'] == cluster_id]
    df_cluster = df_cluster.drop('Cluster', axis=1)
    df_cluster.hist()
    plt.title(f"Istogrammi {cluster_name}")
    plt.show()

